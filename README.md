# Hashing algorithmas

VU block-chain pirma užduotis

# Paleidimas
Per cmd eilute nusigaukite i C:Hash\Hash-algorithm\Hash-algorithm\bin\Debug\net5.0 ir paleiskite komanda su 3 parametrais ir inputu/failo pavadinimu:
 - hash-algorithm -in | -inf -out | -outf <-t> <inputs | filenames>

    - -in - Skaitymas iš komandos eilutės
    - -inf - Skaitymas iš failų
    - -out - Rezultatų išvedimas į komandinę eilutę
    - -outf - Rezultatų išvedimas į failą
    - -t - neprivalomas parametras, atlieka visus testus (output length, are hashes equal ,collision, similarity, speed tests)
    
# Hashingo logika
  Pagrindine ideja yra naudojant XOR ir bit bit rotations, bei atsisiktinai paimtus skaicius daugybai, padaryti atsitiktini bitu eilute.
  
# Hash funkcijos analize
  - Funkcijos input gali būti bet kokio ilgio
  - Funkcijos įšvestis visada bus 64 simbolių hex'as
  - Funkcija yra deterministinė: tam pačiam input visada bus toks pat output
  - Funkcija atspari kolizijai: buvo atlikta 100000 testų su skirtingais input string'ais ir nebuvo aptikta jokių kolizijų
  
 # Konstitucijos suhashinimas 
  -Apie : 00:00:00.0100435ms
  
 # Hash'ų skirtingumo testų rezultatai: 
    - Mažiausias skirtumas HEX lygmenyje:  39.06%
    - Didžiausias skirtumas HEX lygmenyje: 100.00%
    - Mažiausias skirtumas HEX lygmenyje: 83.02%

    - Mažiausias skirtumas Binary lygmenyje: 0.00%
    - Didžiausias skirtumas Binary lygmenyje: 100.00%
    - Mažiausias skirtumas Binary lygmenyje:  11.32%
