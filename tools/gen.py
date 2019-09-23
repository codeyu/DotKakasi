import os
import re

import json
from six import unichr

class Genkanwadict(object):
    records = {}

    def run(self, src, dst):
        with open(src, 'rb') as f:
            for line in f:
                self.parsekdict(line.decode("utf-8"))
            f.close()
        self.kanwaout(dst)

    # for itaiji and kana dict

    def mkdict(self, src, dst):
        max_key_len = 0
        dic = {}
        with open(src, "rb") as f:
            for line in f:
                line = line.decode("utf-8").strip()
                if line.startswith(';;'):  # skip comment
                    continue
                if re.match(r"^$", line):
                    continue
                try:
                    (v, k) = (re.sub(r'\\u([0-9a-fA-F]{4})',
                                     lambda x: unichr(int(x.group(1), 16)), line)).split(' ')
                    dic[k] = v
                    max_key_len = max(max_key_len, len(k))
                except ValueError:
                    raise Exception("Cannot process dictionary line: ", line)
        result = json.dumps(dic,ensure_ascii=False)
        fo = open(dst, "w", encoding='utf-8') 
        fo.write(result)   
        fo.close()

    # for kanwadict

    def parsekdict(self, line):
        line = line.strip()
        if line.startswith(';;'):  # skip comment
            return
        (yomi, kanji) = line.split(' ')
        if ord(yomi[-1:]) <= ord('z'):
            tail = yomi[-1:]
            yomi = yomi[:-1]
        else:
            tail = ''
        self.updaterec(kanji, yomi, tail)

    def updaterec(self, kanji, yomi, tail):
        key = "%04x" % ord(kanji[0])
        if key in self.records:
            if kanji in self.records[key]:
                rec = self.records[key][kanji]
                rec.append((yomi, tail))
                self.records[key].update({kanji: rec})
            else:
                self.records[key][kanji] = [(yomi, tail)]
        else:
            self.records[key] = {}
            self.records[key][kanji] = [(yomi, tail)]

    def kanwaout(self, out):
        result = json.dumps(self.records,ensure_ascii=False)
        fo = open(out, "w", encoding='utf-8') 
        fo.write(result)   
        fo.close()

    def generate_dictionaries(self, dstdir):
        DICTS = [
            ('itaijidict.utf8', 'itaijidict.json'),
            ('hepburndict.utf8', 'hepburndict.json'),
            ('kunreidict.utf8', 'kunreidict.json'),
            ('passportdict.utf8', 'passportdict.json'),
            ('hepburnhira.utf8', 'hepburnhira.json'),
            ('kunreihira.utf8', 'kunreihira.json'),
            ('passporthira.utf8', 'passporthira.json')
        ]
        srcdir = os.path.join('data')
        if not os.path.exists(dstdir):
            os.makedirs(dstdir)
        for (src_f, dst_f) in DICTS:
            src = os.path.join(srcdir, src_f)
            dst = os.path.join(dstdir, dst_f)
            if (os.path.exists(dst)):
                os.unlink(dst)
            self.mkdict(src, dst)
        src = os.path.join(srcdir, 'kakasidict.utf8')
        dst = os.path.join(dstdir, 'kanwadict.json')
        if (os.path.exists(dst)):
            os.unlink(dst)
        self.run(src, dst)

kanwa = Genkanwadict()
dstdir = os.path.join('json')
kanwa.generate_dictionaries(dstdir)
print("done")