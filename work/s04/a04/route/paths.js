/**
 * General paths.
 */
"use strict";

const express = require("express");
const router  = express.Router();

// Add a route for the path /
router.get("/", (req, res) => {
    res.send("Hello World");
});

// Add a route for the path /about
router.get("/about", (req, res) => {
    res.send("About something");
});

// Add a route for the path /lotto
router.get("/lotto", (req, res) => {

        var lottery = "<!DOCTYPE html> <html> <head> <style> table, th, td { border: 1px solid black; border-collapse: collapse; }"+
        "</style> </head> <body> <caption>The Lottery!</caption> <table style="+"width:100%"+ "> <tr>";

        var randArray = [];
        for(let i = 0; i < 7; i++){
            while(true){
                var nbr = Math.floor(Math.random()*35) +1;
                if(!(randArray.includes(nbr))){
                    randArray[i] = nbr;
                    console.log(randArray[i]);
                    break;
                }
            }
        }
        
    for(let i = 1; i < 36; i++) {
       
        if(randArray.includes(i)){
        lottery += "<td bgcolor="+"grey"+">"+i+"</td>"
        } else {
            lottery += "<td>"+i+"</td>" 
        }

    }
    lottery += "</tr> </table> </body> </html>";

    res.send(lottery)

    
});

module.exports = router;
