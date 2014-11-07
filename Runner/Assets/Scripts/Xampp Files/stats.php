<?php
    // Send variables for the MySQL database class.
    	$username= $_REQUEST['username'];

    $database = mysql_connect('localhost', 'root', '')
 or die('Could not connect: ' . mysql_error());

    mysql_select_db('runner') or die('Could not select database');
 
     $query = "SELECT * FROM score where username = '".$username."' ORDER BY Timestamp;";
    $result = mysql_query($query) or die('Query failed: ' . mysql_error());
   // $query1="SELECT username , score FROM data";
  //  $result1=mysql_query($query1) or die('Query failed: ' . mysql_error());
	
 
  $num_results = mysql_num_rows($result);  
 
//echo "No." . "\t" . "Username" ."\t \t" . "Coinscollected" . "\t" . "Average" . "\t" . "leftmove" . "\t" . "rightmove" . "\t" . "timeplayed" ."\t" . "time of play". "\n";

    for($i = 0; $i < $num_results; $i++)
    {
         $row = mysql_fetch_array($result);
         echo $i+1 . "\t" . $row['Username'] ."\t \t \t" . $row['coinscollected'] . "\t" . $row['Average'] . "\t" . $row['leftmove'] . "\t" . $row['rightmove'] . "\t" . $row['Timeplayed'] ."\t" . $row['TimeStamp'];
	echo "\n";
    }
?>