# come creo la tabella
def Init(telefono, cornetta):
    cornetta.execute("DROP TABLE IF EXISTS camere")
    cornetta.execute("""
        CREATE TABLE IF NOT EXISTS camere (
            idcamera INTEGER PRIMARY KEY AUTOINCREMENT,
            idtipo INTEGER,
            nome TEXT,
            prezzo FLOAT
        )
    """)
    
def Tendina(cornetta, tabella, pk, descrizione):
    # prima ti dò le opzioni
    dati = cornetta.execute(f"SELECT {pk}, {descrizione} FROM {tabella}")
    buffer = []
    for riga in dati:
        buffer.append(f"{riga[0]}:{riga[1]}")
        
    print( " / ".join(buffer) )
    # poi ascolto e resituisco la tua risposta
    return input(f"Scegli {pk}:\t")

# come inserisco i dati in tabella
def Inserisci(telefono, cornetta):
    cornetta.execute(
        "INSERT INTO camere (idtipo, nome, prezzo) VALUES (?, ?, ?)", 
        (
            int( Tendina(cornetta, "tipi", "idtipo", "tipo") ),
            str(input("Nome:\t")), 
            float(input("Prezzo:\t"))
        )
    )
    telefono.commit()

# come estraggo i dati dalla tabella
def Vedi(telefono, cornetta):
    dati = cornetta.execute("""
        SELECT *
        FROM camere
    """)
    for riga in dati:
        print(riga)

# come aggiorno i dati in tabella
def Aggiorna(telefono, cornetta):
    cornetta.execute(
        "UPDATE camere SET idtipo=?, nome=?, prezzo=? WHERE idcamera=?",
        (
            int( Tendina(cornetta, "tipi", "idtipo", "tipo") ),
            str( input("Nome:\t") ),
            float( input("Prezzo:\t") ), 
            int(input("Id da modificare:\t"))
        )
    )
    telefono.commit()

# come cancello i dati in tabella
def Cancella(telefono, cornetta):
    cornetta.execute(
        "DELETE FROM camere WHERE idcamera=?", 
        (
            int( Tendina(cornetta, "camere", "idcamera", "nome") ),
        )
    )
    telefono.commit()

def Main(telefono, cornetta):
    print("-" * 20)
    print("Gestione CAMERE")
    print("-" * 20)
    inEsecuzione = True
    while(inEsecuzione):
        comando = input("camere>")
        if comando == "add": # Create
            Inserisci(telefono, cornetta)
        elif comando == "see": # Read
            Vedi(telefono, cornetta)
        elif comando == "mod": # Update
            Aggiorna(telefono, cornetta)
        elif comando == "del": # Delete
            Cancella(telefono, cornetta)
        elif comando == "exit": # Exit
            inEsecuzione = False
        elif comando == "reset": # Recreate
            Init(telefono, cornetta)
        else:
            print("comando sconosciuto")