<?php
    // Send variables for the MySQL database class.
    	$username= $_REQUEST['username'];

    $database = mysql_connect('localhost', 'root', '')
 or die('Could not connect: ' . mysql_error());

    mysql_select_db('runner') or die('Could not select database');
 
     $query = "SELECT * FROM score where username = '".$username."' ORDER BY coinscollected DESC LIMIT 5;";
    $result = mysql_query($query) or die('Query failed: ' . mysql_error());
   // $query1="SELECT username , score FROM data";
  //  $result1=mysql_query($query1) or die('Query failed: ' . mysql_error());
	
 
    $num_results = mysql_num_rows($result); 
  //  $column_result = mysql_num_columns($result1); 
 
   for($i = 0 ; $i < $num_results; $i++)
    {  
        $row = mysql_fetch_array($result);
       //  $column = mysql_fetch_array($result1);

         echo $row['Username'] ."\n" . $row['coinscollected'] . "\n" . $row['Average'] . "\n" . $row['leftmove'] . "\n" . $row['rightmove'] . "\n" . $row['Timeplayed'] ." \n" . $row['TimeStamp']. "\n";

		 
	// echo " " .$row['score']  ;
	// echo "<br>";

    }
   
    



?>