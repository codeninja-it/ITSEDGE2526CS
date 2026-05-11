db = {}
while True:
    comando = input("db>")
    if comando == "C": # create
        chiave = input("chiave: ")
        valore = input("valore: ")
        db[chiave] = valore;
    elif comando == "D": # delete
        chiave = input("chiave: ")
        del db[chiave]
    elif comando == "R": # read
        chiave = input("chiave: ")
        print(db[chiave])
    elif comando == "A": # all
        print(db)
    elif comando == "L": # carica da file
        pass
    elif comando == "S": # salva su file
        pass
    elif comando == "Q": # exit
        print("Addio!")
        exit