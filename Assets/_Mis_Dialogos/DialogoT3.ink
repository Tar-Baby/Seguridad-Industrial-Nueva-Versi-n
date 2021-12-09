-> main

=== main ===             
Se te ofrece algo?
* [Estás muy cerca del monitor.]
    -> chosen("Monitor")

* [Nada, solo estoy observando.]
    Bueno...
    
    -> DONE
    
=== chosen(Monitor) ===
 ¡Buen chiste! Es que así trabajo mejor.
* [Puedes lastimar tus ojos y espalda.]
    Bueno, tienes razón. Ya me alejo, gracias.
        * * [Adiós]
        -> DONE
        
* [Eso disminuye tu productividad.]
    No creo que sea verdad. Hasta luego.
        * * [Adiós]
        -> DONE
        

        
        
    -> END

//los corchetes sirven para que la respuesta no se imprima