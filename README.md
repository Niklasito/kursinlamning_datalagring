# Kursinlämning Datalagring

Välkommen!

Det här repot består av min inlämningsuppgift i Datalagring.

Applikationen är ett verktyg för att lämna in bilen hos en mekaniker.
Användaren kan skapa ett felärende och får skriva i sina uppgifter som sedan lagras i databasen. 
Det ligger ifrån början 2 felärenden inlagada i databasen. För att söka på dessa felärenden kan man skriva in följande registreringsnummer:

### ABC123
### NET702

I applikationen kan man som användare söka efter sitt registreringsnummer för att se status på sitt eget felärende.

I menyval 3 på huvudmenyn kan man som personal se alla ärenden, uppdatera status på ett ärende, samt lägga till kommentar/er på ett ärende.


# Vy över huvudmeny

![image](https://user-images.githubusercontent.com/110826266/227719927-a2aa1384-d684-4d4a-a02a-a69583b9cf4b.png)


# Vy för att se status på ett ärende

![image](https://user-images.githubusercontent.com/110826266/227720111-9812db69-4ac3-4330-9bd5-bee656192e00.png)

# Vy för att se alla ärenden

![image](https://user-images.githubusercontent.com/110826266/227720722-e8aa6bcd-593d-4517-9cfc-0568fa239baf.png)

# Vy för att se mekanikernas menyval

![image](https://user-images.githubusercontent.com/110826266/227720778-dd66a99b-105d-466a-a482-159ac9572740.png)


# Vidareutveckling av applikationen.

Det här är en applikation som skulle kunna behöva en del mer saker för att bli helt komplett. Exempelvis skulle det vara bra om man skulle behöva identifiera sig som anställd för att logga in på menyval 3. Det vore också bra att isåfall kunna knyta vilken mekaniker som har ändrat status samt skrivit en viss kommentar.
Utöver detta skulle också menyn kunna ha en lite mer utförlig layout och diverse olika val, såsom att skapa en ny bilägare som måste logga in för att se sitt fordon etc.

# Tankar och reflektioner.

Det har varit ett väldigt givande projekt även om jag stundtals har stött på en del problem. Jag är nöjd med resultatet men det finns som sagt en hel del funktioner som skulle kunna vidareutvecklas med applikationen. Jag kan känna att jag från början kunde ha strukturerat upp min databas annorlunda för att få den lite mer lättarbetad. Relationen mellan de olika tabellerna kan jag stundtals uppleva som lite komplex då det finns vissa "kedje-relationer" Exempelvis ErrorReportEntity har en relation till VehiclesEntity som i sin tur har en relation till CarOwnersEntity. Då alla uppgifter samlas in på en och samma gång måste jag i många funktioner inkludera väldigt många tabeller. Det skulle säkerligen kunnat ha gjorts annorlunda.

För att summera känner jag mig nöjd och jag är glad över att kunna presentera detta arbete.

# Niklas Andersson

