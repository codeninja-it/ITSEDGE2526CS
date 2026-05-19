import funzioni

# come creo la tabella
def Init(telefono, cornetta):
    cornetta.execute("DROP TABLE IF EXISTS prenotazioni")
    cornetta.execute("""
        CREATE TABLE IF NOT EXISTS prenotazioni (
            idprenotazione INTEGER PRIMARY KEY AUTOINCREMENT,
            idcamera INTEGER,
            idcliente INTEGER,
            note TEXT
        )
    """)

# come inserisco i dati in tabella
def Inserisci(telefono, cornetta):
    cornetta.execute(
        "INSERT INTO prenotazioni (idcamera, idcliente, note) VALUES (?, ?, ?)", 
        (
            int( funzioni.Tendina(cornetta, "camere", "idcamera", "nome") ),
            int( funzioni.Tendina(cornetta, "clienti", "idcliente", ("nome", "cognome")   ) ),
            str(input("Note:\t"))
        )
    )
    telefono.commit()

# come estraggo i dati dalla tabella
def Vedi(telefono, cornetta):
    dati = cornetta.execute("""
        SELECT prenotazioni.idprenotazione, camere.nome AS camera,
        CONCAT(clienti.nome, ' ', clienti.cognome) AS cliente
        FROM camere
        LEFT JOIN prenotazioni ON camere.idcamera=prenotazioni.idcamera
        LEFT JOIN clienti ON prenotazioni.idcliente=clienti.idcliente
    """)
    print("|idprenotazione\t|camera\t|cliente\t|")
    for riga in dati:
        print( "|" + "\t|".join(riga) + "\t|" )

# come aggiorno i dati in tabella
def Aggiorna(telefono, cornetta):
    cornetta.execute(
        "UPDATE prenotaziono SET idcamera=?, idcliente=?, note=? WHERE idprenotazione=?",
        (
            int( funzioni.Tendina(cornetta, "camere", "idcamera", "nome") ),
            int( funzioni.Tendina(cornetta, "clienti", "idcliente", ("nome", "cognome") ) ),
            str( input("Note:\t") ),
            int(input("Id da modificare:\t"))
        )
    )
    telefono.commit()

# come cancello i dati in tabella
def Cancella(telefono, cornetta):
    cornetta.execute(
        "DELETE FROM prenotazioni WHERE idprenotazione=?", 
        (
            int( funzioni.Tendina(cornetta, "prenotazioni", "idprenotazione", "note") ),
        )
    )
    telefono.commit()

def Main(telefono, cornetta):
    print("-" * 20)
    print("Gestione PRENOTAZIONI")
    print("-" * 20)
    inEsecuzione = True
    while(inEsecuzione):
        comando = input("prenotazioni>")
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