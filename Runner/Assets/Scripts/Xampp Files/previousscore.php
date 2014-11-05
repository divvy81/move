<?php
    // Send variables for the MySQL database class.
	$username= $_REQUEST['username'];

    $database = mysql_connect('localhost', 'root', '')
 or die('Could not connect: ' . mysql_error());

    mysql_select_db('Runner') or die('Could not select database');
    //echo $username;
    $query = "SELECT * FROM score where username = '".$username."' ORDER BY TimeStamp DESC LIMIT 1;";
    $result = mysql_query($query) or die('Query failed: ' . mysql_error());
    $row = mysql_fetch_array($result);	
	//echo $result;
	//echo $row['leftmove'];
   // $query1="SELECT username , score FROM data";
  //  $result1=mysql_query($query1) or die('Query failed: ' . mysql_error());
	
 
  //  $num_results = mysql_num_rows($result); 
  //  $column_result = mysql_num_columns($result1); 
 
//   for($i = 0 ; $i < 6; $i++)
//    {  
       // $row = mysql_fetch_array($result);
       //  $column = mysql_fetch_array($result1);
	
	//echo $row;

        echo $row['leftmove']." " . $row['rightmove'] . " " . $row['up'] . " " . $row['down'] . " " . $row['coinscollected'] . " " . $row['Average'] ." " ;

	
		 
	// echo " " .$row['score']  ;
	// echo "<br>";

//    }
   
    



?>