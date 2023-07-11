/* Encoder Library - TwoKnobs Example
 * http://www.pjrc.com/teensy/td_libs_Encoder.html
 *
 * This example code is in the public domain.
 */

#include <Encoder.h>


Encoder knobLeft(5, 6);
Encoder knobRight(7, 8);
//   avoid using pins with LEDs attached

void setup() {
  Serial.begin(9600);
}


void loop() {
  long newLeft, newRight;

  newLeft = knobLeft.read();
  newRight = knobRight.read();

  if (newLeft != positionLeft || newRight != positionRight) {
    // & is the separating character 
    Serial.print(newLeft+"&"+newRight);

    Serial.println();
    positionLeft = newLeft;
    positionRight = newRight;

  }

}