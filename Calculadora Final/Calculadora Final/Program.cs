var continue_Program = true;

while (continue_Program)
{
    try
    {
        Console.WriteLine("==============================================\n");
Console.WriteLine("         PROGRAMA MULTIFUNCIONAL\n");
Console.WriteLine("==============================================\n");
Console.WriteLine("Selecciona el programa que deseas utilizar:");
Console.WriteLine(
    "1. Calculadora Basica\n" +
    "2. Evaluacion Estudiantil\n" +
    "3. Salir del programa principal\n");

Console.WriteLine("Ingresa el numero de la opcion que deseas utilizar: ");

if (!int.TryParse(Console.ReadLine(), out int primary_Entered_Option))
{
    Console.WriteLine("\nIngresa un numero valido por favor");
    continue;
}

switch (primary_Entered_Option)
{
    case 1:
        bool exit_Basic_Calculator = false;

        while (!exit_Basic_Calculator)
        {
            exit_Basic_Calculator = basic_Calculator();
        }
        break;
    case 2:
        bool exit_Student_Evaluation = false;

        while (!exit_Student_Evaluation)
        {
            exit_Student_Evaluation = student_Evaluation();
        }
        break;
    case 3:
        continue_Program = false;
        Console.WriteLine("\nSaliendo del programa principal...");
        break;
    default:
        Console.WriteLine("Opcion invalida. Intenta nuevamente.");
        break;
}
    }
    catch (Exception ex)
    {
    Console.WriteLine("");
    Console.WriteLine($"Error: {ex.Message}\n");
}
}

static bool basic_Calculator()
{
    try
    {
        decimal typed_Number_1;
        decimal typed_Number_2;
        decimal result = 0;
        string operation = "";

        Console.WriteLine("\n==============================================\n");
        Console.WriteLine("             CALCULADORA BASICA");
        Console.WriteLine("\n==============================================\n");

        Console.WriteLine("Selecciona la operacion que deseas realizar ahora:");
        Console.WriteLine(
            "1. SUMA\n" +
            "2. RESTA\n" +
            "3. MULTIPLICACION\n" +
            "4. DIVISION\n" +
            "5. SALIR DE LA CALCULADORA\n");

        Console.WriteLine("Ingresa el numero de la opcion que deseas realizar: ");

        if (!int.TryParse(Console.ReadLine(), out int secondary_Entered_Option))
        {
            Console.WriteLine("Ingresa un numero valido por favor");
            return false;
        }

        if (secondary_Entered_Option == 5)
        {
            Console.WriteLine("\nSaliendo de la calculadora...\n");
            return true;
        }

        if (secondary_Entered_Option < 1 || secondary_Entered_Option > 5)
        {
            Console.WriteLine("Opcion invalida. Intenta nuevamente.");
            return false;
        }

        if (secondary_Entered_Option == 1)
        {
            operation = "SUMA";
        }
        else if (secondary_Entered_Option == 2)
        {
            operation = "RESTA";
        }
        else if (secondary_Entered_Option == 3)
        {
            operation = "MULTIPLICACION";
        }
        else if (secondary_Entered_Option == 4)
        {
            operation = "DIVISION";
        }

        Console.WriteLine($"\nHas seleccionado la operacion de: {operation}\n");

        Console.WriteLine("Ingrese el primer numero: ");
        if (!decimal.TryParse(Console.ReadLine(), out typed_Number_1))
        {
            Console.WriteLine("El numero ingresado no es valido.");
            return false;
        }

        Console.WriteLine("Ingresa el segundo numero: ");
        if (!decimal.TryParse(Console.ReadLine(), out typed_Number_2))
        {
            Console.WriteLine("El numero ingresado no es valido.");
            return false;
        }

        switch (secondary_Entered_Option)
        {
            case 1:
                result = typed_Number_1 + typed_Number_2;

                break;
            case 2:
                result = typed_Number_1 - typed_Number_2;

                break;
            case 3:
                result = typed_Number_1 * typed_Number_2;

                break;
            case 4:
                if (typed_Number_2 == 0)
                {
                    Console.WriteLine("Error: No se puede dividir entre cero.\nIngresa un numero distinto de 0.");
                    return false;
                }
                result = typed_Number_1 / typed_Number_2;
                break;
            default:
                Console.WriteLine("Opcion invalida, seleccione una de las opciones presentadas en el menu inicial.");
                return false;
        }

        Console.WriteLine($"\nEl resultado de la operacion es: {result}\n");
    }
    catch (OverflowException)
    {
        Console.WriteLine("Error: El resultado supera el rango permitido.");

    }
    catch (Exception ex)
    {
        Console.WriteLine("");
        Console.WriteLine($"Error: {ex.Message}\n");
    }
    return false;
}

static bool student_Evaluation()
{
    const int MINIMUN_PASSING_SCORE = 70;
    int student_Grade = 0;
    string approval_Message;
    string? name_Of_Student;
    int terciary_Entered_Option;

    Console.WriteLine("\n==============================================\n");
    Console.WriteLine("           EVALUACION ESTUDIANTIL\n");
    Console.WriteLine("==============================================\n");
    Console.WriteLine("Seleccione la opcion que desea utilizar: \n");
    Console.WriteLine(
        "1. Iniciar\n" +
        "2. Salir\n");

    Console.WriteLine("Ingresa el numero de la opcion a realizar: ");

    if (!int.TryParse(Console.ReadLine(), out terciary_Entered_Option))
    {
        Console.WriteLine("Ingresa un numero valido por favor");
        return false;
    }

    switch (terciary_Entered_Option)
    {
        case 1:
            Console.WriteLine("\nIngrese el nombre del estudiante: ");

            name_Of_Student = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name_Of_Student))
            {
                Console.WriteLine("El nombre no puede estar vacio.");
                return false;
            }

            Console.WriteLine("\nIngrese la calificacion del estudiante: ");

            if (!int.TryParse(Console.ReadLine(), out student_Grade))
            {
                Console.WriteLine("Debes introducir una calificacion valida.");
                return false;
            }

            if (student_Grade < 0 || student_Grade > 100)
            {
                Console.WriteLine("Debes ingresar la calificacion en un rango de (0-100).");
                return false;
            }

            approval_Message = student_Grade >= MINIMUN_PASSING_SCORE ? "Aprobo" : "Reprobo";

            Console.WriteLine("Evaluando...\n");
            Console.WriteLine($"El estudiante {name_Of_Student}: {approval_Message}");
            break;
        case 2:
            Console.WriteLine("Saliendo de la evaluacion estudiantil...");
            return true;
        default:
            Console.WriteLine("Opcion invalida. Intenta nuevamente por favor");
            break;
    }
    return false;
}