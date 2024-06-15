using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using static System.Console;
using static System.ConsoleColor;

class Program{

    private static string[] options = {"> About\n", "> Options\n", "> Quit\n"};
    private static int currSelectedIndex;
    public static void Main(string[] args){
        
        string str = @"
  __  __                        
 |  \/  |                       
 | \  / |   ___   _ __    _   _ 
 | |\/| |  / _ \ | '_ \  | | | |
 | |  | | |  __/ | | | | | |_| |
 |_|  |_|  \___| |_| |_|  \__,_|
                                
                                
";
        Input:
        
        
        Write(str + "\n");

        PrintSelections();
        ReadInput();
        Clear();
        goto Input;
    }

    static void PrintSelections(){
        for(int i = 0; i < options.Length; i++){
            if(i == currSelectedIndex){
                currSelectedIndex = i;
                ForegroundColor = Black;
                BackgroundColor = White;
                Write(options[i]);
                ResetColor();
            } else Write(options[i]);
        }
    }

    static void PrintAbout(){
        Clear();
        string aboutmsg = @"This is a simple menu system. This was developed in order to learn how to make selectable options 
        and to build up prior knowledge for future programs. Current controls are:";
        string choices = "\n\nEnter -> to select the currently highlighted option\nUpArrow -> to go up\nDownArrow -> to go down";

        Write(aboutmsg + choices);
        ForegroundColor = Black;
        BackgroundColor = White;
        Write("\n\n> Back");
        ResetColor();
        if(ReadKey().Key == ConsoleKey.Enter) return;
    }

    static void PrintOptions(){
        Clear();
        string msg = "Currently no customizable options. This is a simple demo after all";
        Write(msg);

        ForegroundColor = Black;
        BackgroundColor = White;
        Write("\n\n> Back");
        ResetColor();
        if(ReadKey().Key == ConsoleKey.Enter) return;
    }

    static void ReadInput(){
        switch(ReadKey().Key){
            case ConsoleKey.Enter:
                if(currSelectedIndex == 2) Environment.Exit(0);
                else if (currSelectedIndex == 0) PrintAbout();
                else if (currSelectedIndex == 1) PrintOptions();
                break;
            case ConsoleKey.DownArrow:
                CurrSelectedIndex += 1;
                break;
            case ConsoleKey.UpArrow:
                CurrSelectedIndex -= 1;
                break;
        }
        // if(ReadKey().Key == ConsoleKey.Enter && currSelectedIndex == 2) Environment.Exit(0);
        // else if(ReadKey().Key == ConsoleKey.DownArrow) CurrSelectedIndex += 1;
        // else if (ReadKey().Key == ConsoleKey.UpArrow) CurrSelectedIndex -= 1;
    }

    public static int CurrSelectedIndex{
        set{
            if(value >= options.Length || value < 0){
                return;
            } else currSelectedIndex = value;
        } get {return currSelectedIndex;}
    }

    
}