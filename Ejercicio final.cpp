void task1()
{
    enum class Task1States
    {
        INIT,
        CONFIG,
        WAIT_DATA
    };

    static Task1States task1state = Task1States::CONFIG;
    static uint32_t timeCounter = 5;
    static uint32_t countdownTimer = 0;
    static const uint32_t MAX_TIME = 40;
    static const uint32_t MIN_TIME = 1;
    static  uint32_t INTERVAL = 1000;
    static char arreglo[5]; 

    switch (task1state)
    {
        case Task1States::INIT:
        {
            task1state = Task1States::CONFIG;
            break;

        }
        
        case Task1States::CONFIG:
        {
        //Serial.print("CONFIG");
           if (Serial.available() > 0) 
        {
            char key;
           do {
                key = Serial.read();
                
                    if (key == 'S' && timeCounter < MAX_TIME) 
                    {
                        timeCounter++;
                        Serial.print("Tiempo establecido: ");
                        Serial.println(timeCounter);
                    } 
                    else if (key == 'B' && timeCounter > MIN_TIME) 
                    {
                        timeCounter--;
                        Serial.print("Tiempo establecido: ");
                        Serial.println(timeCounter);
                    }
                
                
            } while (key != 'L');
            countdownTimer = timeCounter;
            task1state = Task1States::WAIT_DATA;
            break;
        }
    
        case Task1States::WAIT_DATA:
        {
            if(countdownTimer > 0)
            {
                while (countdownTimer >0 || !typedCode())
                {
                uint32_t currentTime = millis();
                static uint32_t previousTime = currentTime;
                if (currentTime - previousTime >= 1000) 
                { // Actualiza cada segundo
                    previousTime = currentTime;
                    countdownTimer--;
                    Serial.print("Tiempo restante: ");
                    Serial.println(countdownTimer);
                    if (typedCode())
                    {
                        Serial.print("SALVASTE EL MUNDO");
                        delay(10);
                        task1state = Task1States::INIT;
                    }
                    else if (countdownTimer == 0)
                    {
                        Serial.print("RADIACIÓN NUCLEAR ACTIVA\n");
                        delay(10);
                        task1state = Task1States::INIT;
                    }
                     
                }
                
                } 
                
            }
            task1state = Task1States::INIT;
            break;
        }
        default:
        {
            break;
        }
    }
}
}



bool typedCode()
{
    
}

void setup()
{
   Serial.println("Ingresa S para aumentar el tiempo");
    Serial.println("Ingresa B para reducir el tiempo");
    Serial.println("Ingresa L cuando estés listo");
   task1();
   
}

void loop()
{
    task1();
}
