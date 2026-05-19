import sqlite3
import tipi
import clienti
import camere
import prenotazioni

# Gestione dell'entità tipi
telefono = sqlite3.connect("roomtrack.db")
cornetta = telefono.cursor()

# Lista(cornetta, "idutente", "nome", "utenti")
# Lista(cornetta, "idutente", ("nome", "cognome"), "utenti")
def Lista(cornetta, key = "idtipo", value = "tipo", table = "tipi"):
    dati = cornetta.execute(f"SELECT {key}, {value} FROM {table}")
    opzioni = []
    for riga in dati:
        opzioni.append(f"{riga[0]}>{riga[1]}") # 1>singola
    return "[" + ", ".join(opzioni) + "]" # [1>singola, 2>suite]

# ciclo principale
def Main():
    inEsecuzione = True
    while(inEsecuzione):
        comando = input("rtrk>")
        if comando == "tipi":
            tipi.Main(telefono, cornetta)
        elif comando == "clienti":
            clienti.Main(telefono, cornetta)
        elif comando == "camere":
            camere.Main(telefono, cornetta)
        elif comando == "prenotazioni":
            prenotazioni.Main(telefono, cornetta)
        elif comando == "exit":
            inEsecuzione = False
        else:
            print("modulo non installato")
    
    
Main()

telefono.close()
print("Arrivederci!")