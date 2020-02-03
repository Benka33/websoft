function schoolFetching (id) {
    console.log('hej')
//    fetching of the schools
    fetch('data/' +id+ '.json')
        .then((response) => {
            return response.json();
        })
        .then((myJson) => {
            createTable(myJson.Skolenheter);
        });

    
}

function createTable (tableData){
    
    var table = document.getElementById('table');
    var tablecontent = '';
    tablecontent += ("<tr>");

    for (key in tableData[0]) {
        tablecontent += ('<th>' + key + '</th>');
    }

    tablecontent += ("</tr>")

    for (var i = 0; i < tableData.length; i++){
        tablecontent += ("<tr>")

        for (key in tableData[i]) {
            tablecontent += ('<td>' + tableData[i][key] + '</td>');
        }

        tablecontent += ("</tr>")
    }

    table.innerHTML = tablecontent;

}