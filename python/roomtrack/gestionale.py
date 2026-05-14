import sqlite3
import tipi

# Gestione dell'entità tipi
telefono = sqlite3.connect("roomtrack.db")
cornetta = telefono.cursor()

# ciclo principale
def Main():
    inEsecuzione = True
    while(inEsecuzione):
        comando = input("rtrk>")
        if comando == "tipi":
            tipi.GestioneTipi(telefono, cornetta)
        elif comando == "exit":
            inEsecuzione = False
        else:
            print("modulo non installato")
    
    
Main()

telefono.close()
print("Arrivederci!")