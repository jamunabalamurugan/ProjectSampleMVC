create database testOnline
use testOnline
CREATE TABLE QUESTION
(
QUESTION_ID INT PRIMARY KEY IDENTITY(1, 1),
TECHNOLOGY_ID INT,
QUESTION VARCHAR(1000),
OPTION1 VARCHAR(500),
OPTION2 VARCHAR(500),
OPTION3 VARCHAR(500),
OPTION4 VARCHAR(500),
RIGHT_ANSWER INT,
TEST_LEVEL INT,
FOREIGN KEY(TECHNOLOGY_ID) REFERENCES TECHNOLOGY(TECHNOLOGY_ID)
)

SELECT * FROM QUESTION
-----------------------------------------------------------------------------------PYTHON------------------------------------------------------------------

INSERT INTO QUESTION VALUES
(5,
'Is Python case sensitive when dealing with identifiers?',
'1) yes',
'2) no',
'3) machine dependent',
'4) none of the mentioned',
1,
1)
INSERT INTO QUESTION VALUES
(5,
'What is the maximum possible length of an identifier?',
'1) 31 characters',
'2) 63 characters',
'3) 79 characters',
'4) none of the mentioned',
4,
1)
INSERT INTO QUESTION VALUES
(5,
'Why are local variable names beginning with an underscore discouraged?',
'1) they are used to indicate a private variables of a class',
'2) they confuse the interpreter',
'3) they are used to indicate global variables',
'4) they slow down execution',
1,
1)
INSERT INTO QUESTION VALUES
(5,
'Which of the following is not a keyword?',
'1) eval',
'2) assert',
'3) nonlocal',
'4) pass',
1,
1)
INSERT INTO QUESTION VALUES
(5,
'Which of the following is true for variable names in Python?',
'1) unlimited length',
'2) all private members must have leading and trailing underscores',
'3) underscore and ampersand are the only two special characters allowed',
'4) none of the mentioned',
1,
1)
INSERT INTO QUESTION VALUES
(5,
'Which is the correct operator for power(xy)?',
'1) X^y',
'2) X**y',
'3) X^^y',
'4) None of the mentioned',
2,
1)
INSERT INTO QUESTION VALUES
(5,
'Which of the following is not a keyword?',
'1) eval',
'2) assert',
'3) nonlocal',
'4) pass',
1,
1)
INSERT INTO QUESTION VALUES
(5,
'What is the output of this expression, 3*1**3?',
'1) 27',
'2) 9',
'3) 3',
'4) 1',
3,
1)
INSERT INTO QUESTION VALUES
(5,
'Which of these in not a core data type?',
'1) Lists',
'2) Dictionary',
'3) Tuples',
'4) Class',
4,
1)
INSERT INTO QUESTION VALUES
(5,
'Given a function that does not return any value, What value is thrown by default when executed in shell.',
'1) int',
'2) bool',
'3) void',
'4) None',
4,
1)
INSERT INTO QUESTION VALUES
(5,
'Which of the following commands will create a list?',
'1) list1 = list()',
'2) list1 = []',
'3) list1 = list([1, 2, 3])',
'4) all of the mentioned',
4,
1)
INSERT INTO QUESTION VALUES
(5,
'What is the output when we execute list(“hello”)?',
'1) [‘h’, ‘e’, ‘l’, ‘l’, ‘o’]',
'2) [‘hello’] ',
'3) [‘llo’]',
'4) [‘olleh’]',
1,
2)
INSERT INTO QUESTION VALUES
(5,
'Suppose list1 is [3, 5, 25, 1, 3], what is min(list1)?',
'1) 3',
'2) 5',
'3) 25',
'4 1',
4,
2)
INSERT INTO QUESTION VALUES
(5,
'Suppose d = {“john”:40, “peter”:45}, to delete the entry for “john” what command do we use?',
'1) d.delete(“john”:40)',
'2) d.delete(“john”)',
'3) del d[“john”]',
'4) del d(“john”:40)',
3,
2)
INSERT INTO QUESTION VALUES
(5,
'Suppose d = {“john”:40, “peter”:45}. To obtain the number of entries in dictionary which command do we use?',
'1) d.size()',
'2) len(d)',
'3) size(d)',
'4) d.len()',
2,
2)
INSERT INTO QUESTION VALUES
(5,
'Which of the following functions is a built-in function in python?',
'1) seed()',
'2) sqrt()',
'3) factorial()',
'4) print()',
4,
2)
INSERT INTO QUESTION VALUES
(5,
'The function pow(x,y,z) is evaluated as:',
'1) (x**y)**z',
'2) (x**y) / z',
'3) (x**y) % z',
'4) (x**y)*z',
3,
2)
INSERT INTO QUESTION VALUES
(5,
'Which of these about a frozenset is not true?',
'1) Mutable data type',
'2) Allows duplicate values',
'3) Data type with unordered values',
'4) Immutable data type',
1,
2)
INSERT INTO QUESTION VALUES
(5,
'Which of the following best describes polymorphism?',
'1) Ability of a class to derive members of another class as a part of its own definition',
'2) Means of bundling instance variables and methods in order to restrict access to certain class members',
'3) Focuses on variables and passing of variables to functions',
'4) Allows for objects of different types and behaviour to be treated as the same general type',
4,
2)
INSERT INTO QUESTION VALUES
(5,
'What is the biggest reason for the use of polymorphism?',
'1) It allows the programmer to think at a more abstract level',
'2) There is less program code to write',
'3) The program will have a more elegant design and will be easier to maintain and update',
'4) Program code takes up less space',
3,
2)
INSERT INTO QUESTION VALUES
(5,
'What is the use of duck typing?',
'1) More restriction on the type values that can be passed to a given method',
'2) No restriction on the type values that can be passed to a given method',
'3) Less restriction on the type values that can be passed to a given method',
'4) Makes the program code smaller',
3,
2)
INSERT INTO QUESTION VALUES
(5,
'Which of the following data structures is returned by the functions globals() and locals()?',
'1) list',
'2) set',
'3) dictionary',
'4) tuple',
3,
3)
INSERT INTO QUESTION VALUES
(5,
'What happens if a local variable exists with the same name as the global variable you want to access?',
'1) Error',
'2) The local variable is shadowed',
'3) Undefined behavior',
'4) The global variable is shadowed',
4,
3)
INSERT INTO QUESTION VALUES
(5,
'How many except statements can a try-except block have?',
'1) zero',
'2) one',
'3) more than one',
'4) more than zero',
4,
3)
INSERT INTO QUESTION VALUES
(5,
'When will the else part of try-except-else be executed?',
'1) always',
'2) when an exception occurs',
'3) when no exception occurs',
'4) when an exception occurs in to except block',
3,
3)
INSERT INTO QUESTION VALUES
(5,
'When is the finally block executed?',
'1) when there is no exception',
'2) when there is an exception',
'3) only if some condition that has been specified is satisfied',
'4) always',
4,
3)
INSERT INTO QUESTION VALUES
(5,
'What happens when ‘1’ == 1 is executed?',
'1) we get a True',
'2) we get a False',
'3) an TypeError occurs',
'4) a ValueError occurs',
2,
3)
INSERT INTO QUESTION VALUES
(5,
'Which of the following best describes inheritance?',
'1) Ability of a class to derive members of another class as a part of its own definition',
'2) Means of bundling instance variables and methods in order to restrict access to certain class members',
'3) Focuses on variables and passing of variables to functions',
'4) Allows for implementation of elegant software that is well designed and easily modified',
1,
3)
INSERT INTO QUESTION VALUES
(5,
'What does built-in function type do in context of classes?',
'1) Determines the object name of any value',
'2) Determines the class name of any value',
'3) Determines class description of any value',
'4) Determines the file name of any value',
2,
3)
INSERT INTO QUESTION VALUES
(5,
'Which of the following is not a type of inheritance?',
'1) Double-level',
'2) Multi-level',
'3) Single-level',
'4) Multiple',
1,
3)
INSERT INTO QUESTION VALUES
(5,
'What does built-in function help do in context of classes?',
'1) Determines the object name of any value',
'2) Determines the class identifiers of any value',
'3) Determines class description of any built-in type',
'4) Determines class description of any user-defined built-in type',
3,
3)
SELECT*FROM QUESTION
----------------------------------------------------------------------------------------PHP----------------------------------------------------------------

INSERT INTO QUESTION VALUES
(4,
'Which function is used to erase all session variables stored in the current session?',
'1) session_destroy()',
'2) session_change()',
'3) session_remove()',
'4) session_unset()',
4,
1)
INSERT INTO QUESTION VALUES
(4,
'What will the function session_id() return is no parameter is passed?',
'1) Current Session Identification Number',
'2) Previous Session Identification Number',
'3) Last Session Identification Number',
'4) Error',
1,
1)

INSERT INTO QUESTION VALUES
(4,
'Which one of the following statements should you use to set the session username to Nachi?',
'1) $SESSION[‘username’] = “Nachi”;',
'2) $_SESSION[‘username’] = “Nachi”;',
'3) session_start(“nachi”);',
'4) $SESSION_START[“username”] = “Nachi”;',
2,
1)

INSERT INTO QUESTION VALUES
(4,
'An attacker somehow obtains an unsuspecting user’s SID and then using it to impersonate the user in order to gain potentially sensitive information. This attack is known as __________',
'1) session-fixation',
'2) session-fixing',
'3) session-hijack',
'4) session-copy',
1,
1)


INSERT INTO QUESTION VALUES
(4,
'Which parameter determines whether the old session file will also be deleted when the session ID is regenerated?',
'1) delete_old_file',
'2) delete_old_session',
'3) delete_old_session_file',
'4) delete_session_file',
2,
1)


INSERT INTO QUESTION VALUES
(4,
'Which function effectively deletes all sessions that have expired?',
'1) session_delete()',
'2) session_destroy()',
'3) session_garbage_collect()',
'4) SessionHandler::gc',
4,
1)

INSERT INTO QUESTION VALUES
(4,
'Which function is used to transform PHP’s session-handler behavior into that defined by your custom handler?',
'1) session_set_save()',
'2) session_set_save_handler()',
'3) Session_handler()',
'4) session_save_handler()',
2,
1)

INSERT INTO QUESTION VALUES
(4,
'The session_start() function must appear _________',
'1) after the html tag',
'2) after the body tag',
'3) before the body tag',
'4) before the html tag',
4,
1)

INSERT INTO QUESTION VALUES
(4,
'What is the return type of session_set_save_handler() function?',
'1) boolean',
'2) integer',
'3) float',
'4) character',
1,
1)

INSERT INTO QUESTION VALUES
(4,
'Which one of the following databases has PHP supported almost since the beginning?',
'1) Oracle Database',
'2) SQL',
'3) SQL+',
'4) MySQL',
4,
1)

INSERT INTO QUESTION VALUES
(4,
'The updated MySQL extension released with PHP 5 is typically referred to as _______________',
'1) MySQL',
'2) mysql',
'3) mysqli',
'4) mysqly',
3,
2)

INSERT INTO QUESTION VALUES
(4,
'Which one of the following lines need to be uncommented or added in the php.ini file so as to enable mysqli extension?',
'1) extension=php_mysqli.dll',
'2) extension=mysql.dll',
'3) extension=php_mysqli.dl',
'4) extension=mysqli.dl',
1,
2)

INSERT INTO QUESTION VALUES
(4,
'In which version of PHP was MySQL Native Driver(also known as mysqlnd) introduced?',
'1) PHP 5.0',
'2) PHP 5.1',
'3) PHP 5.2',
'4) PHP 5.3',
4,
2)

INSERT INTO QUESTION VALUES
(4,
'Which one of the following statements instantiates the mysqli class?',
'1) mysqli = new mysqli()',
'2) $mysqli = new mysqli()',
'3) $mysqli->new.mysqli()',
'4) mysqli->new.mysqli()',
2,
2)

INSERT INTO QUESTION VALUES
(4,
'Which one of the following statements can be used to select the database?',
'1) $mysqli=select_db("databasename");',
'2) mysqli=select_db("databasename");',
'3) mysqli->select_db("databasename");',
'4) $mysqli->select_db("databasename");',
4,
2)

INSERT INTO QUESTION VALUES
(4,
'Which one of the following methods can be used to diagnose and display information about a MySQL connection error?',
'1) connect_errno()',
'2) connect_error()',
'3) mysqli_connect_errno()',
'4) mysqli_connect_error()',
3,
2)


INSERT INTO QUESTION VALUES
(4,
'Which method returns the error code generated from the execution of the last MySQL function?',
'1) errno()',
'2) errnumber()',
'3) errorno()',
'4) errornumber()',
1,
2)

INSERT INTO QUESTION VALUES
(4,
'If there is no error, then what will the error() method return?',
'1) TRUE',
'2) FALSE',
'3) Empty String',
'4) 0',
3,
2)

INSERT INTO QUESTION VALUES
(4,
'Which one of the following statements should be used to include a file?',
'1) #include "filename";',
'2) include "filename";',
'3) @include "filename";',
'4) #include <filename>;',
2,
2)

INSERT INTO QUESTION VALUES
(4,
'Which one of the following methods is responsible for sending the query to the database?',
'1) query()',
'2) send_query()',
'3) sendquery()',
'4) mysqli_query()',
4,
2)

INSERT INTO QUESTION VALUES
(4,
'Which one of the following methods recuperates any memory consumed by a result set?',
'1) destroy()',
'2) mysqli_free_result()',
'3) alloc()',
'4) free()',
2,
3)

INSERT INTO QUESTION VALUES
(4,
'Which one of the following method is used to retrieve the number of rows affected by an INSERT, UPDATE, or DELETE query?',
'1) num_rows()',
'2) affected_rows()',
'3) changed_rows()',
'4) mysqli_affected_rows()',
4,
3)

INSERT INTO QUESTION VALUES
(4,
'Which of the following methods is used to execute the statement after the parameters have been bound?',
'1) bind_param()',
'2) bind_result()',
'3) bound_param()',
'4) bound_result()',
1,
3)

INSERT INTO QUESTION VALUES
(4,
'Which one of the following methods is used to recuperating prepared statements resources?',
'1) end()',
'2) finish()',
'3) mysqli_close()',
'4) close()',
3,
3)

INSERT INTO QUESTION VALUES
(4,
'Which method retrieves each row from the prepared statement result and assigns the fields to the bound results?',
'1) get_row()',
'2) fetch_row()',
'3) fetch()',
'4) mysqli_fetch_row()',
4,
3)

INSERT INTO QUESTION VALUES
(4,
'Which method rolls back the present transaction?',
'1) commit()',
'2) undo()',
'3) mysqli_rollback()',
'4) rollback()',
3,
3)

INSERT INTO QUESTION VALUES
(4,
'Fill in the blank with the best option. An Object is a/an ________ of a class.',
'1) type',
'2) prototype',
'3) instance',
'4) object',
3,
3)

INSERT INTO QUESTION VALUES
(4,
'Which characters is used to access property variables on an object-by-object basis?',
'1) ::',
'2) =',
'3) ->',
'4) .',
3,
3)

INSERT INTO QUESTION VALUES
(4,
'Code that uses a class, function, or method is often described as the ____________',
'1) client code',
'2) user code',
'3) object code',
'4) class code',
1,
3)

INSERT INTO QUESTION VALUES
(4,
'Which directive determines whether PHP scripts on the server can accept file uploads?',
'1) file_uploads',
'2) file_upload',
'3) file_input',
'4) file_intake',
1,
3)
SELECT*FROM QUESTION
----------------------------------------------------------C#------------------------------------------

INSERT INTO QUESTION VALUES
(3,
'How many Bytes are stored by ‘Long’ Data type in C# .net?',
'1) 8',
'2) 4',
'3) 2',
'4) 1',
1,
1
)

INSERT INTO QUESTION VALUES
(3,

'Correct Declaration of Values to variables ‘a’ and ‘b’?',
'1) int a = 32, b = 40.6;',
'2) int a = 42; b = 40;',
'3) int a = 32; int b = 40;',
'4) int a = b = 42;',
3,
1
)

INSERT INTO QUESTION VALUES
(3,

'Arrange the following data type in order of increasing magnitude sbyte, short, long, int.',
'1) long < short < int < sbyte',
'2) sbyte < short < int < long',
'3) short < sbyte < int < long',
'4) short < int < sbyte < long',
2,
1
)

INSERT INTO QUESTION VALUES
(3,

'Which of the following is used to define the member of a class externally?',

'1) :',
'2) ::',
'3) #',
'4) none of the mentioned',
2,
1
)
INSERT INTO QUESTION VALUES
(3,

'What is the most specified using class declaration?',
'1) type',
'2) scope',
'3) type & scope',
'4) none of the mentioned',
3,
1
)


INSERT INTO QUESTION VALUES
(3,

'“A mechanism that binds together code and data in manipulates, and keeps both safe from outside interference and misuse. In short it isolates a particular code and data from all other codes and data. A well-defined interface controls access to that particular code and data.”',
'1) Abstraction',
'2) Polymorphism',
'3) Inheritance',
'4) Encapsulation',
4,
1
)
INSERT INTO QUESTION VALUES
(3,

'The data members of a class by default are?',
'1) protected, public',
'2) private, public',
'3) private',
'4) public',
3,
1
)
INSERT INTO QUESTION VALUES
(3,

'Which keyword is used to refer baseclass constructor to subclass constructor?',
'1) This',
'2) Static',
'3) Base',
'4) Extend',
3,
1
)
INSERT INTO QUESTION VALUES
(3,

'Correct statement about constructor overloading in C# is?',
'1) Overloaded constructors have the same name as the class',
'2) Overloaded constructors cannot use optional arguments',
'3) Overloaded constructors can have different type of number of arguments as well as differ in number of arguments',
'4) All of the mentioned',
3,
1
)
INSERT INTO QUESTION VALUES
(3,

'The capability of an object in Csharp to take number of different forms and hence display behaviour as according is known as ___________',
'1) Encapsulation',
'2) Polymorphism',
'3) Abstraction',
'4) None of the mentioned',
2,
1
)

INSERT INTO QUESTION VALUES
(3,

'Which of the following keyword is used to change data and behavior of a base class by replacing a member of the base class with a new derived member?',
'1) Overloads',
'2) Overrides',
'3) new',
'4) base',
3,
2
)
INSERT INTO QUESTION VALUES
(3,

'Correct way to overload +operator?',
'1) public sample operator + (sample a, sample b)',
'2) public abstract operator + (sample a,sample b)',
'3) public static sample operator + (sample a, sample b)',
'4) all of the mentioned',
4,
2
)
INSERT INTO QUESTION VALUES
(3,

'Which of the following statements is correct?',
'1) Each derived class does not have its own version of a virtual method',
'2) If a derived class does not have its own version of virtual method then one in base class is used',
'3) By default methods are virtual',
'4) All of the mentioned',
3,
2
)
INSERT INTO QUESTION VALUES
(3,

'Selecting appropriate method out of number of overloaded methods by matching arguments in terms of number, type and order and binding that selected method to object at compile time is called?',
'1) Static binding',
'2) Static Linking',
'3) Compile time polymorphism',
'4) All of the mentioned',
4,
2
)
INSERT INTO QUESTION VALUES
(3,

'The ‘ref’ keyword can be used with which among the following?',
'1) Static function/subroutine',
'2) Static data',
'3) Instance function/subroutine',
'4) All of the mentioned ',
1,
2
)
INSERT INTO QUESTION VALUES
(3,

'To implement delegates, the necessary condition is?',
'1) class declaration',
'2) inheritance',
'3) runtime polymorphism',
'4) exceptions',
1,
2
)
INSERT INTO QUESTION VALUES
(3,

'To generate a simple notification for an object in runtime, the programming construct to be used for implementing this idea?',
'1) namespace',
'2) interface',
'3) delegate',
'4) attribute',
3,
2
)
INSERT INTO QUESTION VALUES
(3,

'Choose the incorrect statement among the following about the delegate?',
'1) delegates are of reference types',
'2) delegates are object oriented',
'3) delegates are type safe',
'4) none of the mentioned',
4,
2
)
INSERT INTO QUESTION VALUES
(3,

'Choose the incorrect statement about delegates?',
'1) delegates are not type safe',
'2) delegates can be used to implement callback notification',
'3) delegate is a user defined type',
'4) delegates permits execution of a method in an asynchronous manner',
1,
2
)

INSERT INTO QUESTION VALUES
(3,


'Which of these constructors is used to create an empty String object?',
'1) String()',
'2) String(void)',
'3) String(0)',
'4) None of the mentioned',
1,
2
)



INSERT INTO QUESTION VALUES
(3,

'Which of these method of class String is used to obtain length of String object?',
'1) get()',
'2) Sizeof()',
'3) Lengthof()',
'4) Length()',
4,
3
)
INSERT INTO QUESTION VALUES
(3,

'Choose the base class for string() method.',
'1) System.Array',
'2) System.char',
'3) System.String',
'4) None of the mentioned',
3,
3
)
INSERT INTO QUESTION VALUES
(3,

'What is the value returned by the function CompareTo() if the invoking string is less than the string compared?',
'1) zero',
'2) value less than zero',
'3) value greater than zero',
'4) none of the mentioned',
2,
3
)
INSERT INTO QUESTION VALUES
(3,

'Which of these methods of class String is used to check whether a given string starts with a particular substring or not?',
'1) StartsWith()',
'2) EndsWith()',
'3) Starts()',
'4) Ends()',
1,
3
)
INSERT INTO QUESTION VALUES
(3,

'What does URL stand for?',
'1) Uniform Resource Locator',
'2) Uniform Resource Latch',
'3) Universal Resource Locator',
'4) Universal Resource Latch',
1,
3
)
INSERT INTO QUESTION VALUES
(3,

'Which of these exceptions is thrown by the URL class’s constructors?',
'1) URLNotFound',
'2) URLSourceNotFound',
'3) MalformedURLException',
'4) URLNotFoundException',
3,
3
)
INSERT INTO QUESTION VALUES
(3,

' Which of these classes is used to encapsulate IP address and DNS?',
'1) DatagramPacket',
'2) URL',
'3) InetAddress',
'4) ContentHandler',
3,
3
)
INSERT INTO QUESTION VALUES
(3,

'Which of these is a standard for communicating multimedia content over email?',
'1) http',
'2) https',
'3) Mime',
'4) httpd',
3,
3
)
INSERT INTO QUESTION VALUES
(3,

'Which of these classes is used to access actual bits or content information of a URL?',
'1) URL',
'2) URLDecoder',
'3) URLConnection',
'4) All of the mentioned',
4,
3
)
INSERT INTO QUESTION VALUES
(3,

'The modifiers used to define an array of parameters or list of arguments is __________',
'1) ref',
'2) out',
'3) param',
'4) var',
3,
3
)

SELECT*FROM QUESTION
---------------------------------------------------------JAVA---------------------------------------------------

INSERT INTO QUESTION VALUES
(1,
'Java programs are',
'1) Faster than others',
'2) Platform independent',
'3) Not reusable',
'4) Not scalable',
2,
1
)

INSERT INTO QUESTION VALUES
(1,
 'Java has its origin in',
'A) C programming language',
'B) PERRL',
'C) COBOL',
'D) Oak programming language',
4,
1
)

INSERT INTO QUESTION VALUES
(1,
 'Which one of the following is true for Java',
'1) Java is object oriented and interpreted',
'2) Java is efficient and faster than C',
'3) Java is the choice of everyone.',
'4) Java is not robust.',
1,
1
)

INSERT INTO QUESTION VALUES
(1,
 'The command javac is used to',
'1) debug a java program',
'2) compile a java program',
'3) interpret a java program',
'4) execute a java program',
2,
1
)

INSERT INTO QUESTION VALUES
(1,
 'Java servlets are an efficient and powerful solution for
creating ………….. for the web.',
'1) Dynamic content',
'2) Static content',
'3) Hardware',
'4) Both a and b',
1,
1
)


INSERT INTO QUESTION VALUES
(1,
 'Filters were officially introduced in the Servlet ………………
specification.',
'1) 2.1',
'2) 2.3',
'3) 2.2',
'4) 2.4',
2,
1
)


INSERT INTO QUESTION VALUES
(1,
 'Which is the root class of all AWT events',
'1) java.awt.ActionEvent',              
'2) java.awt.AWTEvent',
'3) java.awt.event.AWTEvent',
'4) java.awt.event.Event',
2,
1
)

INSERT INTO QUESTION VALUES
(1,

 'which is not OOP features are',
'1) Increasing productivity ',                           
'2)Reusability',
'3) Decreasing maintenance cost ' ,          
'4) High vulnerability',
2,
1
)

INSERT INTO QUESTION VALUES
(1,
 'break statement is used to',
'1) get out of method',                                     
'2)end aprogram',
'3) get out of a loop',                                         
'4)get out of the system',
4,
1
)


INSERT INTO QUESTION VALUES
(1,
 'Native – protocol pure Java converts ……….. into the …………
used by DBMSs directly.',
'1) JDBC calls, network protocol',
'2) ODBC class, network protocol',
'3) ODBC class, user call',
'4) JDBC calls, user call',
1,
1
)

INSERT INTO QUESTION VALUES
(1,
 'The JDBC-ODBC bridge allows ……….. to be used as ………..',
 '1) JDBC drivers, ODBC drivers',
'2) Drivers, Application',
'3) ODBC drivers, JDBC drivers',
'4) Application, drivers',
3,
2
)

INSERT INTO QUESTION VALUES
(1,
 'Which of the following is true about Java.',
'1) Java does not support overloading.',
'2) Java has replaced the destructor function of C++',
'3) There are no header files in Java.',
'4) All of the above.',
4,
2
)


INSERT INTO QUESTION VALUES
(1,
' ……………. are not machine instructions and therefore, Java interpreter generates machine code that can be directly executed by the machine that is running the Java program.',
'1) Compiled Instructions',
'2) Compiled code',
'3) byte code',
'4) Java mid code',
3,
2
)


INSERT INTO QUESTION VALUES
(1,
 'The command javac',
'1) Converts a java program into binary code',
'2) Converts a java program into bytecode',
'3) Converts a java program into machine language',
'4) None of the above.',
2,
2
)



INSERT INTO QUESTION VALUES
(1,
 'Which of the following is not the java primitive type',
'1) Byte',
'2) Float',
'3) Character',
'4) Long doubl',
4,
2
)



INSERT INTO QUESTION VALUES
(1,
 'Command to execute compiled java program is',
'1) java',
'2) javac',
'3) run',
'4) javaw',
1,
2
)



INSERT INTO QUESTION VALUES
(1,
  'which is not Java Servlet',
'1) is key component of server side java development ' ,   
'2) is a small pluggable extension to a server that enhances functionality',
'3) runs only in Windows Operating System',
'4) allows developers to customize any java enabled server',

3,
2
)



INSERT INTO QUESTION VALUES
(1,
 'Inner classes are',
'1) anonymous classes',
'2) nested classes',
'3) sub classes',
'4) derived classes',
2,
2
)


INSERT INTO QUESTION VALUES
(1,

 'How many times does the following code segment execute
int x=1, y=10, z=1;
do{y–; x++; y-=2; y=z; z++} while (y>1 && z<10);',
'1) 1',
'2) 10',
'3) 5',
'4) infinite',
1,
2
)


INSERT INTO QUESTION VALUES
(1,
' State which following statement is false for EJB.',
'1. EJB exists in the middle-tier',
'2. EJB specifies an execution environment',
'3. EJB supports transaction processing',
'4.all the above',
4,
2
)



INSERT INTO QUESTION VALUES
(1,
' All java classes are derived from',
'1) java.lang.Class',
'2) java.util.Name',
'3) java.lang.Object',
'4) java.awt.Window',
3,
3
)

INSERT INTO QUESTION VALUES
(1,
' The jdb is used to',
'1) Create a jar archive',
'2) Debug a java program',
'3) Create C header file',
'4) Generate java documentation',
2,
3
)

INSERT INTO QUESTION VALUES
(1,
'What would happen if “String[]args” is not
included as argument in the main method.',
'1) No error',
'2) Compilation error',
'3) Program won’t run',
'4) Program exit',
3,
3
)

INSERT INTO QUESTION VALUES
(1,
'For execution of DELETE SQL query in JDBC, ………….
method must be used.',
'1) executeQuery()',
'2) executeDeleteQuery()',
'3) executeUpdate()',
'4) executeDelete()',
3,
3
)


INSERT INTO QUESTION VALUES
(1,
' Which method will a web browser call on a new applet?',
'1) main method',
'2) destroy method',
'3) execute method',
'4) init method',
4,
3
)


INSERT INTO QUESTION VALUES
(1,
' Which of the following is not mandatory in variable declaration?',
'1) a semicolon',
'2) an identifier',
'3) an assignment',
'4) a data type',
3,
3
)

INSERT INTO QUESTION VALUES
(1,
' When a program class implements an interface, it must
provide behavior for',
'1) two methods defined in that interface',
'2) any methods in a class',
'3) only certain methods in that interface',
'4) all methods defined in that interface',
4,
3
)

INSERT INTO QUESTION VALUES
(1,
' In order to  run JSP
………………..  is required.',
'1) Mail Server',
'2)Applet viewer',
'3) Java Web Server',
'4) Database connection',
3,
3
)

INSERT INTO QUESTION VALUES
(1,
' Which one is true?',
'1) AWT is an extended version of swing',
'2) Paint( ) of Applet class cannot be overridden',
'3)none of above',
'4)All the above',

3,
3
)


INSERT INTO QUESTION VALUES
(1,
 'Prepared Statement object in JDBC used to execute………..
queries',
'1) Executable',
'2) Simple',
'3) High level',
'4) Parameterized',
4,
3
)
SELECT*FROM QUESTION
------------------------------------------------------C/C++-------------------------------------------

SELECT*FROM QUESTION



INSERT INTO QUESTION VALUES
(6,
'Declaration a pointer more than once may cause ____ ?',
'1)Error',
'2)Abort',
'3)Trap',
'4)Null',
3,
1)


INSERT INTO QUESTION VALUES
(6,
'Which one is not a correct variable type in C++?',
'1)float',
'2).real',
'3)int',
'4)double',
2,
1)


INSERT INTO QUESTION VALUES
(6,
'Which operation is used as Logical "AND"?',
'1)Operator-&',
'2)Operator-||',
'3)Operator-&&',
'4)Operator +',
 3,
1)



INSERT INTO QUESTION VALUES
(6,	
'An expression A.B in C++ means ____?',
'1)A is member of object B',
'2)B is member of Object A',
'3)Product of A and B',
'4)None of these',
2,
1)



INSERT INTO QUESTION VALUES
(6,	
'C++ code line ends with ___?',
'1)A Semicolon (;)',
'2)A Fullstop(.)',
'3)A Comma (,)',
'4)A Slash (/)',
 1,
1)


INSERT INTO QUESTION VALUES
(6,	
'Who is known as the father of C Language ?',
'1)James A. Sosling',
'2).Vjarne Stroustrup',
'3)Dennis Ritchie',
'4)Dr. E. F. Codd',
3,
1)


INSERT INTO QUESTION VALUES
(6,
'C Language was developed in the year ____?',
'1)1970',
'2)1975',
'3)1980',
'4)1985',
1,
1)

INSERT INTO QUESTION VALUES
(6,
'Which one is not a reserve keyword in C Language?',
'1)auto',
'2)main',
'3)case',
'4)register',
2,
1)

INSERT INTO QUESTION VALUES
(6,	
'C variable name can start with a ____?',
'1)Number',
'2)Plus Sign (+)',
'3)Underscore',
'4)Asterisk (*)',
3,
1)


INSERT INTO QUESTION VALUES
(6	,
'Prototype of a function means _____?',
'1)Name of Function',
'2)Output of Function',
'3)Declaration of Function',
'4)Input of a Function',
3,
1)



INSERT INTO QUESTION VALUES
(6,
'______ function is used to allocate space for array in memory.?',
'1)malloc()',
'2)realloc()',
'3)alloc()',
'4)calloc()',
4,
2)

INSERT INTO QUESTION VALUES
(6,
'ponter pointing to a variable that is not initialized is called ____?',
'1)Void Pointer',
'2)Null Pointer',
'3)Empty Pointer',
'4)Wild Pointer',
2,
2)


INSERT INTO QUESTION VALUES
(6,
'Default constructor has ____ arguments?',
'1)No argument',
'2)One Argument',
'3)Two Argument',
'4)None of these',
1,
2)


INSERT INTO QUESTION VALUES
(6,
'class whos objects can not be created is known as _____?',
'1)Absurd Class',
'2)Dead Class',
'3)Super Class',
'4)Abstract Class',
4,
2)



INSERT INTO QUESTION VALUES
(6,	
'Which class allows only one object to be created?',
'1)Nuclear Family Class',
'2)Abstruct Class',
'3)Singleton Class',
'4).Numero Uno Class',
3,
2)

INSERT INTO QUESTION VALUES
(6,
'Name the loop that executes at least once.?',
'1)For',
'2)If',
'3)do-while',
'4)while',
3,
2)

INSERT INTO QUESTION VALUES
(6,	
'Far pointer can access _____?',
'1)Single memory location',
'2)No memory location',
'3)All memory location',
'4)First and Last Memory Address',
3,
2)


INSERT INTO QUESTION VALUES
(6,	
'A pointer pointing to a memory location of the variable even after deletion of the variavle is known as _____?',
'1)far pointer',
'2)dangling pointer',
'3)null pointer',
'4)void pointer',
2,
2)


INSERT INTO QUESTION VALUES
(6,	
'An uninitialized pointer in C is called ___?',
'1)Constructor',

'2)dangling pointer',
'3)Wild Pointer',
'4)Destructor',
3,
2)


INSERT INTO QUESTION VALUES
(6,	
'A pointer that is pointing to NOTHING is called ____?',
'1)VOID Pointer',
'2)DANGLING Pointer',
'3)NULL Pointer',
'4)WILD Pointer',
3,
2)

INSERT INTO QUESTION VALUES
(6,	
'Reusability of code in C++ is achieved through ____?',
'1)Polymorphism',
'2)Inheritance',
'3)Encapsulation',
'4)Both A and B',
2,
3)

INSERT INTO QUESTION VALUES
(6,	
'In CPP, members of a class are ______ by default.',
'1)Public',
'2)Private',
'3)Protected',
'4)Static',
2,
3)


INSERT INTO QUESTION VALUES
(6,	
'In C++ Program, inline fuctions are expanded during ____',
'1)Run Time',
'2)Compile Time',
'3)Debug Time',
'4)Coding Time',
1,
3)


INSERT INTO QUESTION VALUES
(6,	
'To perform file input / output operation in C++, we must include which header file ?',
'1)<fiostream>',
'2)<ifstream>',
'3).<ofstream>',
'4)<fstream>',
3,
3)



INSERT INTO QUESTION VALUES
(6,
'An exceptio in C++ can be generated using which keywords.?',
'1)thrown',
'2)threw',
'3)throw',
'4)throws',
3,
3)

INSERT INTO QUESTION VALUES
(6,
'Which of the following constructors are provided by the C++ compiler if not defined in a class?',
'1) Default constructor',
'2) Assignment constructor',
'3) Copy constructor',
'4) All of the mentioned',
4,
3)

INSERT INTO QUESTION VALUES
(6,
'When a copy constructor is called?',
'1) When an object of the class is returned by value',
'2) When an object of the class is passed by value to a function',
'3) When an object is constructed based on another object of the same class',
'4) All of the mentioned',
4,
3)
INSERT INTO QUESTION VALUES
(6,
'Which header file is required to use file I/O operations?',
'1) <ifstream>',
'2) <ostream>',
'3) <fstream>',
'4) <iostream>',
3,
3)
INSERT INTO QUESTION VALUES
(6,
'Which of the following is not used as a file opening mode?',
'1) ios::trunc',
'2) ios::binary',
'3) ios::in',
'4) ios::ate',
1,
3)
INSERT INTO QUESTION VALUES
(6,
'What is the use of ios::trunc mode?',
'1) To open a file in input mode',
'2) To open a file in output mode',
'3) To truncate an existing file to half',
'4) To truncate an existing file to zero',
4,
3)

SELECT*FROM QUESTION
-----------------------------------------------------SQL---------------------------------------------

INSERT INTO QUESTION VALUES
(2,
'DML is provided for?',
'1) Description of logical structure of database',
'2) Addition of new structure in the database system',
'3) Manipulation & processing of database',
'4) Definition of physical structure of database system',
3,
1)

INSERT INTO QUESTION VALUES
(2,
' ’AS’ clause is used in SQL for?',
'1) Selection operation',
'2) Rename Operation',
'3) Join operation',
'4) Projection Operation',
2,
1)

INSERT INTO QUESTION VALUES
(2,
'Count function in SQL returns the number of?',
'1) values',
'2) distinct values',
'3) groups',
'4) columns',
1,
1)


INSERT INTO QUESTION VALUES
(2,
 'The statement in SQL which allows to change the definition of a table is?',
'1) Alter',
'2) Update',
'3) Create',
'4) Select',
1,
1)

INSERT INTO QUESTION VALUES
(2,
'Which of the following is correct.?',
'1) A SQL query automatically eliminates duplicates',
'2) SQL permits attribute names to be repeated in the same relation',
'3) A SQL query will not work if there are no indexes on the relations',
'4) None of the above',
4,
1)


INSERT INTO QUESTION VALUES
(2,
' Which of the following operation is used if we are interested in only certain columns of a table?',
'1) PROJECTION',
'2) SELECTION',
'3) UNION',
'4) JOIN',
1,
1)

 
INSERT INTO QUESTION VALUES
(2,
' Which of the following is a legal expression in SQL?',
'1) SELECT NULL FROM EMPLOYEE;',
'2) SELECT NAME FROM EMPLOYEE;',
'3) SELECT NAME FROM EMPLOYEE WHERE SALARY=NULL;',
'4) None of the above',
2,
1)

INSERT INTO QUESTION VALUES
(2,
' Which of the following is a valid SQL type?',
'1) CHARACTER',
'2) NUMERIC',
'3) FLOAT',
'4) All of the above',
4,
1)


INSERT INTO QUESTION VALUES
(2,
'Which command is used to select distinct subject (SUB) from the table (BOOK)?',
'1) SELECT ALL FROM BOOK',
'2) SELECT DISTINCT SUB FROM BOOK',
'3) SELECT SUB FROM BOOK',
'4) All of the above',
2,
2)



INSERT INTO QUESTION VALUES
(2,
' In SQL, which of the following is not a data definition language commands?',
'1) RENAME',
'2) REVOKE',
'3) GRANT',
'4) UPDATE',
4,
1)




INSERT INTO QUESTION VALUES
(2,
'……………………. are predefined and maintained SQL Server and users cannot assign or directly change the values.?',
'1) Global variables',
'2) Local Variables',
'3) Integer Variables',
'4) Floating Variables',
1,
2)

INSERT INTO QUESTION VALUES
(2,
' A local variable is shown ……………………… preceding its name.?',
'1) One @ symbol',
'2) Two @@ symbol',
'3) One # symbol',
'4) Two ## symbol',
1,
2)

INSERT INTO QUESTION VALUES
(2,
' Constraint checking can be disabled on existing ……….. and …………. constraints so that any data you modify or add to the table is not checked against the constraint.?',
'1) CHECK, FOREIGN KEY',
'2) DELETE, FOREIGN KEY',
'3) CHECK, PRIMARY KEY',
'4) PRIMARY KEY, FOREIGN KEY',
1,
2)


INSERT INTO QUESTION VALUES
(2,
'……………. and ………………. are the Transact – SQL control-of-flow key words?.',
'1) Continue, Stop',
'2) Break, Stop',
'3) Continue, While',
'4) While, Going to',
3,
2)


INSERT INTO QUESTION VALUES
(2,
'The type of constraint …………………… specifies data values that are acceptable in a column?',
'1) DEFAULT',
'2) CHECK',
'3) PRIMARY',
'4) UNIQUE',
2,
2)


INSERT INTO QUESTION VALUES
(2,
' The ………………… constraint defines a column or combination of columns whose values match the primary key of the same or another table.?',
'1) DEFAULT',
'2) CHECK',
'3) PRIMARY',
'4) FOREIGN KEY',
4,
2)


 INSERT INTO QUESTION VALUES
(2,
'The control-of-flow statement ………………… defines conditional, and optionally, alternate execution when a condition is FALSE.?',
'1) WHILE',
'2) WAITFOR',
'3) IF……..ELSE',
'4) BEGIN………. END',
3,
2)


INSERT INTO QUESTION VALUES
(2,
'In SQL Server, ………………… is based on relationships between foreign keys and primary keys or between foreign keys and unique keys.?',
'1) Entity integrity',
'2) Domain integrity',
'3) Referential integrity',
'4) User-defined integrity',
3,
2)


INSERT INTO QUESTION VALUES
(2,
'When a …………….. clause is used, each item in the select list must produce a single value for each group.?',
'1) ORDER BY',
'2) GROUP',
'3) GROUP BY',
'4) GROUP IN',
3,
2)


INSERT INTO QUESTION VALUES
(2,
' MS SQL Server uses a variant of SQL called T-SQL, or Transact SQL, an implementation of ……………… with some extensions.?',
'1) MS SQL Server',
'2) Tabular Data Set',
'3) SQL-92',
'4) Tabular Data Stream',
3,
2)


INSERT INTO QUESTION VALUES
(2,
' In SQL, which command is used to remove a stored function from the database?',
'1) REMOVE FUNCTION',
'2) DELETE FUNCTION',
'3) DROP FUNCTION',
'4) ERASE FUNCTION',
3,
3)

INSERT INTO QUESTION VALUES
(2,
'In SQL, which command is used to select only one copy of each set of duplicate rows?',
'1) SELECT DISTINCT',
'2) SELECT UNIQUE',
'3) SELECT DIFFERENT',
'4) All of the above',
1,
3)

INSERT INTO QUESTION VALUES
(2,
' Count function in SQL returns the number of?',
'1) Values',
'2) Distinct values',
'3) Groups',
'4) Columns',
1,
3)

INSERT INTO QUESTION VALUES
(2,
'Composite key is made up of …………….?',
'1) One column',
'2) One super key',
'3) One foreign key',
'4) Two or more columns',
4,
3)

INSERT INTO QUESTION VALUES
(2,
 'What command is used to get back the privileges offered by the GRANT command?',
'1) Grant',
'2) Revoke',
'3) Execute',
'4) Run',
2,
3)


INSERT INTO QUESTION VALUES
(2,
' Which command displays the SQL command in the SQL buffer, and then executes it?',
'1) CMD',
'2) OPEN',
'3) EXECUTE',
'4) RUN',
4,
3)

 INSERT INTO QUESTION VALUES
(2,
'What is a DATABLOCK?',
'1) Set of Extents',
'2) Set of Segments',
'3) Smallest Database storage unit',
'4) Set of blocks',
3,
3)


INSERT INTO QUESTION VALUES
(2,
' If two groups are not linked in the data model editor, what is the hierarchy between them?',
'1) There is no hierarchy between unlinked groups.',
'2) The group that is right ranks higher than the group that is to right or below it.',
'3) The group that is above or leftmost ranks higher than the group that is to right or below it.',
'4) The group that is left ranks higher than the group that is to the right.',
3,
3)


INSERT INTO QUESTION VALUES
(2,
'Which of the following types of triggers can be fired on DDL operations?',
'1) Instead of Trigger',
'2) DML Trigger',
'3) System Trigger',
'4) DDL Trigger',
3,
3)


INSERT INTO QUESTION VALUES
(2,
' What operator performs pattern matching?',
'1) IS NULL operator',
'2) ASSIGNMENT operator',
'3) LIKE operator',
'4) NOT operator',
3,
3)

SELECT * FROM QUESTION