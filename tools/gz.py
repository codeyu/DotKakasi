import os, gzip

INPUT_FILES=['hepburndict.json','hepburnhira.json','itaijidict.json','kanwadict.json','kunreidict.json','kunreihira.json','passportdict.json','passporthira.json']

for f in INPUT_FILES:
        source = os.path.join('json', f)
        input = open(source, 'rb')
        s = input.read()
        input.close()
        dest = os.path.join('../src/DotKakasi/_gz', f+'.gz')
        output = gzip.GzipFile(dest, 'wb')
        output.write(s)
        output.close()
print("done")