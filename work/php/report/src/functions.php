<?php

/**
 * Open the database file and catch the exception it it fails
 *
 * @var array $dsn with connection details
 *
 * @return object database connection
 */
function connectDatabase(array $dsn)
{
    try {
        $database = new PDO(
            $dsn["dsn"],
            $dsn["username"],
            $dsn["password"]);

        $database->setAttribute(PDO::ATTR_DEFAULT_FETCH_MODE, PDO::FETCH_ASSOC);
        $database->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    } catch (PDOException $exception) {
        echo "Failed to connect to the database using DSN:<br>\n";
        print_r($dsn);
        throw $exception;
    }

    return $database;
}
