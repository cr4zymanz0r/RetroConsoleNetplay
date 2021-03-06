// Buffer to store incoming commands from serial port
String inData = "";

//pin 14 - 21 is pin A0 to 07
int a = 7;	// up			//DB15 pin 15
int b = 9;	// down			//DB15 pin 7
int c = 6;	// left			//DB15 pin 14
int d = 8;	// right		//DB15 pin 6
int e = 17;	// select/coin	//DB15 pin 3
int f = 3;	// start		//DB15 pin 11
int g = 5;	// button 1		//DB15 pin 13
int h = 19;	// button 2		//DB15 pin 5
int i = 4;	// button 3		//DB15 pin 12
int j = 18;	// button 4		//DB15 pin 4
int k = 2;	// button 5		//DB15 pin 10
int l = 16;	// button 6		//DB15 pin 2

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
