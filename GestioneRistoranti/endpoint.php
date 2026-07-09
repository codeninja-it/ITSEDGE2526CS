<?php
    ini_set("display_errors", 0);
    $dbcon = new mysqli("127.0.0.1", "root", "password", "db");
    
    header("Content-Type: application/json");
    
    $risposta_ok = array("status" => "ok", "message" => "fatto!");
    $risposta_errore = array("status" => "error", "message" => "errore di esecuzione...");
    
    $azione = isset($_GET["act"]) ? $_GET["act"] : "default";
    $id = isset($_GET["id"]) ? intval($_GET["id"]) : 0;
    $key = isset($_GET["key"]) ? htmlentities($_GET["key"]) : "idtavolo";
    $table = isset($_GET["tab"]) ? htmlentities($_GET["tab"]) : "tavoli";
    
    // tavoli.php?act=see&tab=comande&key=idcomanda&id=3
    
    switch($azione){
        case "see":
            try {
                $dati = $dbcon->query("SELECT * FROM {$table} WHERE {$key}={$id} LIMIT 1;");
                $riga = $dati->fetch_assoc();
                echo( json_encode($riga, JSON_NUMERIC_CHECK) );
            } catch (Exception $e) {
                //echo( $e->getMessage() );
                echo( json_encode($risposta_errore) );
            }
            break;
        
        case "del":
            try {
                $risultato = $dbcon->query("DELETE FROM {$table} WHERE {$key}={$id} LIMIT 1;");
                echo( json_encode($risposta_ok) );
            } catch (Exception $e) {
                echo( json_encode($risposta_errore) );
            }
            break;
        
        case "ins":
            try {
                $campi = [];
                $valori = [];
                foreach($_POST as $chiave => $valore){
                    $campi[] = $chiave;
                    if(is_numeric($valore)){
                        $valori[] = $valore;
                    } else {
                        $valori[] = "\"{$valore}\"";
                    }
                }
                $campi = implode($campi, ", ");
                $valori = implode($valori, ", ");
                
                $dbcon->query("INSERT INTO {$table} ({$campi}) VALUES ({$valori});");
                echo( json_encode($risposta_ok) );
            } catch (Exception $e) {
                echo( json_encode($risposta_errore) );
            }
            break;
        
        default:
            try {
                $dati = $dbcon->query("SELECT * FROM {$table};");
                $buffer = [];
                while($riga = $dati->fetch_assoc()){
                    $buffer[] = $riga;
                }
                echo( json_encode($buffer, JSON_NUMERIC_CHECK) );
            } catch (Exception $e) {
                echo( json_encode($risposta_errore) );
            }
            break;
    }