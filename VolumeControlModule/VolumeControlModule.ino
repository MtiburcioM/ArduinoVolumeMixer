const int pots = 5;

int volumes[pots] = {
  100,    // master volume
  100,    // browser
  100,    // spotify
  100,    // discord
  100     // games
};

void setup() {
  Serial.begin(9600);
}

void loop() {
  potentiometer("m", 0); // Master
  potentiometer("b", 1); // Browser
  potentiometer("s", 2); // Spotify
  potentiometer("d", 3); // Discord
  potentiometer("g", 4); // Games
  
  delay(5); // breaks without delay
}

void potentiometer(String c, int pin) {
  int potVal = analogRead(pin);
  potVal = map(potVal, 0, 1024, 0, 101);

  if(potVal != volumes[pin]) {
    volumes[pin] = potVal;
    Serial.println(c + volumes[pin]);
  }
}
