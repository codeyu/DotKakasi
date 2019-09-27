import pykakasi
text = u"本蓮沼"
kakasi = pykakasi.kakasi()
kakasi.setMode("J","aF") # Japanese to furigana
kakasi.setMode("H","aF") # Japanese to furigana
conv = kakasi.getConverter()
result = conv.do(text)
print(result)