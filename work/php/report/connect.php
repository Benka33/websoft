<?php
$pageTitle = "Connect";
require "config.php";
require "src/functions.php";
require "view/header.php";

// database connection
$database = connectDatabase($dsn);

// SQL statement that select all in the tech table
$statement = $database->prepare("SELECT * FROM tech");
$statement->execute();

// Get the results as an array with column names as array keys
$result = $statement->fetchAll();   

?><h1>Database connection</h1>

<table>
    <tr>
        <th>ID</th>
        <th>Label</th>
        <th>Type</th>
    </tr>

<?php foreach($result as $row) : ?>
    <tr>
        <td><?= $row["id"] ?></td>
        <td><?= $row["label"] ?></td>
        <td><?= $row["type"] ?></td>
    </tr>
<?php endforeach; ?>

</table>

<?php require "view/footer.php"; ?>
