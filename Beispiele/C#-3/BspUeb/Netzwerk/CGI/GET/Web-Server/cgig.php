<?php
 $vorname = $_GET["vorname"];
 $nachname = $_GET["nachname"];
 echo "<html>\n<head><title>CGI-Demo</title>\n</head>\n";
 echo "<body>\n<h1>Hallo, ".$vorname." ".$nachname."!</h1>\n</body>\n</html>";
?>