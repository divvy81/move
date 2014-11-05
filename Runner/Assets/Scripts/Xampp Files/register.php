<?php 

	$user =$_REQUEST['username'] ;
        $pass = $_REQUEST['password'];

        $db = mysql_connect('localhost', 'root', '') or die('Could not connect: ' . mysql_error()); 
        mysql_select_db('Runner') or die('Could not select database');
 
        // Strings must be escaped to prevent SQL injection attack.
 
         
        
 
  
 
            $query = "INSERT INTO users (Username,Password) VALUES ('$user','$pass');";	 


            $result = mysql_query($query)  or die('Query failed:' . mysql_error());

		
		echo "registered";
  ?>