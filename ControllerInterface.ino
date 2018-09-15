// Buffer to store incoming commands from serial port
String inData = "";

int a = 2;	// up
int b = 3;	// down
int c = 4;	// left
int d = 5;	// right
int e = 6;	// select/coin
int f = 7;	// start
int g = 8;	// button 1
int h = 9;	// button 2
int i = 10;	// button 3
int j = 11;	// button 4
int k = 12;	// button 5
int l = 14;	// button 6

void setup()
{
	Serial.begin(9600);
	//Serial.begin(38400);
	Serial.println("Serial connection started, waiting for inputs...");
	
	pinMode(l, INPUT);
}

void loop()
{
	while(Serial.available() > 0) // maybe replace with == \n on actual hardware
	{
		char received = Serial.read();
		inData += received;
		
		// Process message when new line character is recieved
		if (received == '0' || received == '1')
		{
			Serial.print("Arduino Received: ");
			Serial.print(inData);
			Serial.println();
			
			switch(inData[0])
			{
				case 'a':
					//do stuff
					if(inData[1] == '1') // Button was pressed
					{
						pinMode(a, OUTPUT);
						digitalWrite(a, LOW);
					}
					else if(inData[1] == '0') // Button no longer pressed
					{
						pinMode(a, INPUT);
					}
					break;
				case 'b':
					//do stuff
					if(inData[1] == '1') // Button was pressed
					{
						pinMode(b, OUTPUT);
						digitalWrite(b, LOW);
					}
					else if(inData[1] == '0') // Button no longer pressed
					{
						pinMode(b, INPUT);
					}
					break;
				case 'c':
					//do stuff
					if(inData[1] == '1') // Button was pressed
					{
						pinMode(c, OUTPUT);
						digitalWrite(c, LOW);
					}
					else if(inData[1] == '0') // Button no longer pressed
					{
						pinMode(c, INPUT);
					}
					break;
				case 'd':
					//do stuff
					if(inData[1] == '1') // Button was pressed
					{
						pinMode(d, OUTPUT);
						digitalWrite(d, LOW);
					}
					else if(inData[1] == '0') // Button no longer pressed
					{
						pinMode(d, INPUT);
					}
					break;
				case 'e':
					//do stuff
					if(inData[1] == '1') // Button was pressed
					{
						pinMode(e, OUTPUT);
						digitalWrite(e, LOW);
					}
					else if(inData[1] == '0') // Button no longer pressed
					{
						pinMode(e, INPUT);
					}
					break;
				case 'f':
					//do stuff
					if(inData[1] == '1') // Button was pressed
					{
						pinMode(f, OUTPUT);
						digitalWrite(f, LOW);
					}
					else if(inData[1] == '0') // Button no longer pressed
					{
						pinMode(f, INPUT);
					}
					break;
				case 'g':
					//do stuff
					if(inData[1] == '1') // Button was pressed
					{
						pinMode(g, OUTPUT);
						digitalWrite(g, LOW);
					}
					else if(inData[1] == '0') // Button no longer pressed
					{
						pinMode(g, INPUT);
					}
					break;
				case 'h':
					//do stuff
					if(inData[1] == '1') // Button was pressed
					{
						pinMode(h, OUTPUT);
						digitalWrite(h, LOW);
					}
					else if(inData[1] == '0') // Button no longer pressed
					{
						pinMode(h, INPUT);
					}
					break;
				case 'i':
					//do stuff
					if(inData[1] == '1') // Button was pressed
					{
						pinMode(i, OUTPUT);
						digitalWrite(i, LOW);
					}
					else if(inData[1] == '0') // Button no longer pressed
					{
						pinMode(i, INPUT);
					}
					break;
				case 'j':
					//do stuff
					if(inData[1] == '1') // Button was pressed
					{
						pinMode(j, OUTPUT);
						digitalWrite(j, LOW);
					}
					else if(inData[1] == '0') // Button no longer pressed
					{
						pinMode(j, INPUT);
					}
					break;
				case 'k':
					//do stuff
					if(inData[1] == '1') // Button was pressed
					{
						pinMode(k, OUTPUT);
						digitalWrite(k, LOW);
					}
					else if(inData[1] == '0') // Button no longer pressed
					{
						pinMode(k, INPUT);
					}
					break;
				case 'l':
					//do stuff
					if(inData[1] == '1') // Button was pressed
					{
						pinMode(l, OUTPUT);
						digitalWrite(l, LOW);
					}
					else if(inData[1] == '0') // Button no longer pressed
					{
						pinMode(l, INPUT);
					}
					break;
				//default:
					//don't do stuff?
			}
			
			// Do stuff here for button presses
			
			inData = ""; // Clear recieved buffer
		}
	}
}
