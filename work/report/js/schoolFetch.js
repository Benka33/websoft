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
    var htmlTable = '';
    htmlTable += ("<tr>");

    for (value in tableData[0]) {
        htmlTable += ('<th>' + value + '</th>');
    }

    htmlTable += ("</tr>")

    for (var i = 0; i < tableData.length; i++){
        htmlTable += ("<tr>")

        for (value in tableData[i]) {
            htmlTable += ('<td>' + tableData[i][value] + '</td>');
        }

        htmlTable += ("</tr>")
    }

    table.innerHTML = htmlTable;

}