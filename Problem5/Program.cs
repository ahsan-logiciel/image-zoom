try
{
    // Create an instance of StreamReader to read from a file.
    // The using statement also closes the StreamReader.
    using (StreamReader sr = new StreamReader("e:/imagesize.txt"))
    {
        string line;

        if ((line = sr.ReadLine()) != null)
        {
            int test_cases = Convert.ToInt32(line);
            for (int i = 0; i < test_cases; i++)
            {
                //Reading R & Q
                line = sr.ReadLine();
                string[] words = line.Split(' ');
                int R = Convert.ToInt32(words[0]);
                int Q = Convert.ToInt32(words[1]);
                char[,] img = new char[R,R];

                //Reading next R lines and R characters
                for (int j = 0; j < R; j++)
                {
                    line = sr.ReadLine();
                    words = line.Split(' ');
                    for (int k = 0; k < R; k++)
                    {
                        img[j,k] = Convert.ToChar(words[k]);
                        //Console.Write(img[j,k]);
                    }
                    //Console.WriteLine();
                }

                if (Q%R != 0)
                    Console.WriteLine("Not Possible");
                else
                {
                    int count = 0;
                    int mul = Q / R;
                    char[,] img_output = new char[Q, Q];
                    for (int j = 0; j < R; j++)
                    {
                        for (int k = 0; k < R; k++)
                        {
                            //Console.WriteLine("j: "+j + " k: " + k);
                            for (int l = j*mul; l < mul * (j+1); l++)
                            {
                                for (int m = k*mul; m < mul * (k+1); m++)
                                {
                                    //Console.WriteLine("j: " + j + " k: " + k + " l: " + l + " m: " + m);
                                    img_output[l,m] = img[j,k];
                                }
                            }

                            
                        }
                    }
                    for (int temp = 0; temp < Q; temp++)
                    {
                        for (int temp1 = 0; temp1 < Q; temp1++)
                        {
                            Console.Write(img_output[temp, temp1]);
                        }
                        Console.WriteLine();
                    }
                }


            }

        }
    }
}
catch (Exception e)
{
    // Let the user know what went wrong.
    Console.WriteLine("The file could not be read:");
    Console.WriteLine(e.Message);
}


