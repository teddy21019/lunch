<?php
$dbhost="127.0.0.1";
$dbusername="root";
$dbpass="87891363";
$dbname="Lunch";

$date = date("Y-m-d");
$r_name = $_GET['r_name'];
$people = $_GET['people'];
$cost = $_GET['cost'];

$link = mysqli_connect($dbhost,$dbusername,$dbpass,$dbname)or die("MYSQL 連接失敗！");
mysqli_query("SET NAMES 'utf8'");
mysqli_query("SET CHARACTER SET UTF8");
// $sql = "INSERT INTO `lunch`(`ID`, `Date`, `Restaurant_Name`, `Total_people`, `Total_Cost`) VALUES ( null ,'$date','$r_name',$people,$cost)";
// mysqli_query($link, $sql);
// echo $sql;
$sql = "SELECT `Restaurant_Name` FROM `lunch`";
$result = mysqli_query($link,$sql);
while($row = mysqli_fetch_row($result)){
	print_r($row);
}

?>