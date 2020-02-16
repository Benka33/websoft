<?php 
$pageTitle = "Schools";
require "../view/header.php" 
?>

    <head>
        
        <style>table, th, td {
            border: 1px solid black;
            border-collapse: collapse;
          }</style>
    </head> 

        <body>

         
          <script src="js/schoolFetch.js"></script>     

    

            <div id="sel"> 
              <select name="schools" id="schools" onchange="schoolFetching(this.value)">
              <option value="" disabled selected hidden>Choose school district</option>
              <option value="1081" >1081</option>
              <option value="1082" >1082</option>
              </select> 
            </div>
            
            <table id="table">
                
              </table>

        </body>