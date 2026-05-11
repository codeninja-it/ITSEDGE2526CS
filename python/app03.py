# divido un testo in caselle
lista = 'prova di scrittura'.split(' ')
# verbatim
variabile = """
    sefsdf
            sdfsdf
"""
# scrittura su più righe
print("ciao"
      "a"
      "tutti"
)
print(lista)
print(lista[0])
# lo riunisco
insieme = '\t'.join(lista)
print(insieme)
#lo salvo su disco
with open("archivio.csv", "w") as archivio:
    archivio.write(insieme)
    archivio.close()
#lo rileggo
with open("archivio.csv", "r") as archivio:
    contenuto = archivio.read()
    print(contenuto)