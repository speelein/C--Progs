#!/usr/bin/perl
use CGI;
my $query = CGI->new();
print "Content-type: text/html\n\n";
print "<html>\n<head><title>CGI-Demo</title></head>\n<h1>";
print 'Hallo, '.$query->param("vorname").' '.$query->param("nachname").'!';
print "</h1>\n</html>";