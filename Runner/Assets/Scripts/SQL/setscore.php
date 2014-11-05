<?php
	
	
	$user =$_REQUEST['username'] ;
	$left =$_REQUEST['left'] ;
	$right =$_REQUEST['right'] ;
	$up =$_REQUEST['up'] ;
	$down =$_REQUEST['down'] ;
	$Average =$_REQUEST['average'] ;
	$coinscollected =$_REQUEST['score'] ;
	$timeplayed =$_REQUEST['timeplayed'] ;    


        $db = mysql_connect('localhost', 'root', '') or die('Could not connect: ' . mysql_error()); 
        mysql_select_db('Runner') or die('Could not select database');
 
        // Strings must be escaped to prevent SQL injection attack.
 
         
        
 
  
 
            $query = "INSERT INTO score (Username,leftmove,rightmove,up,down,Average,coinscollected,timeplayed) VALUES ('$user','$left','$right','$up','$down','$Average','$coinscollected','$timeplayed');";	 


            $result = mysql_query($query)  or die('Query failed:' . mysql_error());

		
		echo "updated";
  ?>