# come creo la tabella
def Init(telefono, cornetta):
    cornetta.execute("DROP TABLE IF EXISTS clienti")
    cornetta.execute("""
        CREATE TABLE IF NOT EXISTS clienti (
            idcliente INTEGER PRIMARY KEY AUTOINCREMENT,
            nome TEXT,
            cognome TEXT
        )
    """)

# come inserisco i dati in tabella
def Inserisci(telefono, cornetta):
    cornetta.execute(
        "INSERT INTO clienti (nome, cognome) VALUES (?, ?)", 
        (
            input("Nome:\t"), 
            input("Cognome:\t")
        )
    )
    telefono.commit()

# come estraggo i dati dalla tabella
def Vedi(telefono, cornetta):
    dati = cornetta.execute("""
        SELECT *
        FROM clienti
    """)
    for riga in dati:
        print(riga)

# come aggiorno i dati in tabella
def Aggiorna(telefono, cornetta):
    cornetta.execute(
        "UPDATE clienti SET nome=?, cognome=? WHERE idcliente=?",
        (
            input("Nome:\t"), 
            input("Cognome:\t"), 
            int(input("Id da modificare:\t"))
        )
    )
    telefono.commit()

# come cancello i dati in tabella
def Cancella(telefono, cornetta):
    cornetta.execute(
        "DELETE FROM clienti WHERE idcliente=?", 
        (
            int(input("Id da cancellare:\t")),
        )
    )
    telefono.commit()

def Main(telefono, cornetta):
    print("-" * 20)
    print("Gestione CLIENTI")
    print("-" * 20)
    inEsecuzione = True
    while(inEsecuzione):
        comando = input("clienti>")
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