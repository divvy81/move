<?php
	$user = $_GET['username'];
	$pass = $_GET['password'];

	$sqlconnection = mysqli_connect("localhost", "root", "", "Runner");
	if(mysqli_connect_errno()) { 
		echo"failed to connect".mysqli_connect_error(); 
	}

	if(isset($user) && isset($pass)) {
		$query = "SELECT * FROM users WHERE Username = '".$user."' and Password = '".$pass."'";
		$result = mysqli_query($sqlconnection, $query);

		if ($result->num_rows == 0) {
			echo "Nope";
		} else {
			echo "success";
		}
	}
?>