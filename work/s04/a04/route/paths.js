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
    //for(let counter = 1; counter < 8; counter++){
        var rand1 = (Math.random()*35) +1;
        rand1 = parseInt(rand1);
        var rand2 = (Math.random()*35) +1;
        rand2 = parseInt(rand2);
        var rand3 = (Math.random()*35) +1;
        rand3 = parseInt(rand3);
        var rand4 = (Math.random()*35) +1;
        rand4 = parseInt(rand4);
        var rand5 = (Math.random()*35) +1;
        rand5 = parseInt(rand5);
        var rand6 = (Math.random()*35) +1;
        rand6 = parseInt(rand6);
        var rand7 = (Math.random()*35) +1;
        rand7 = parseInt(rand7);
    //}
 
    var lottery = "<!DOCTYPE html> <html> <head> <style> table, th, td { border: 1px solid black; border-collapse: collapse; }"+
     "</style> </head> <body> <caption>The Lottery!</caption> <table style="+"width:100%"+ "> <tr>";
    
    for(let i = 1; i < 36; i++) {
       
        if(i == rand1 || i == rand2 || i == rand3 || i == rand4 || i == rand5 || i == rand6 || i == rand7){
        lottery += "<td bgcolor="+"grey"+">"+i+"</td>"
        } else {
            lottery += "<td>"+i+"</td>" 
        }

        if (i == 35){
            lottery += "</tr> </table> </body> </html>"
        }
    }

    //res.send("<h1>The Lottery!</h1>");
    res.send(lottery)

    
});

module.exports = router;
