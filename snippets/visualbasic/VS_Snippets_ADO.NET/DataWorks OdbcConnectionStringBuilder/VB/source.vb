﻿Option Explicit On
Option Strict On
' <Snippet1>
Imports System.Data.Odbc

Module Module1
    Sub Main()
        Dim builder As New OdbcConnectionStringBuilder With {
            .Driver = "Microsoft Access Driver (*.mdb)"
        }

        ' Call the Add method to explicitly add key/value
        ' pairs to the internal collection.
        builder.Add("Dbq", "C:\info.mdb")

        Console.WriteLine(builder.ConnectionString)
        Console.WriteLine()

        ' Clear current values and reset known keys to their
        ' default values.
        builder.Clear()

        ' Pass the OdbcConnectionStringBuilder an existing
        ' connection string, and you can retrieve and
        ' modify any of the elements.
        builder.ConnectionString =
            "driver={IBM DB2 ODBC DRIVER};Database=SampleDB;" &
            "hostname=SampleServerName;port=SamplePortNum;" &
            "protocol=TCPIP"

        Console.WriteLine("protocol = " & builder("protocol").ToString())
        Console.WriteLine()

        ' Call the Remove method to remove items from
        ' the collection of key/value pairs.
        builder.Remove("port")

        ' Note that calling Remove on a nonexistent item does not
        ' throw an exception.
        builder.Remove("BadItem")
        Console.WriteLine(builder.ConnectionString)
        Console.WriteLine()

        ' The Item property is the default for the class,
        ' and setting the Item property adds the value, if
        ' necessary.
        builder("NewKey") = "newValue"
        Console.WriteLine(builder.ConnectionString)

        Console.WriteLine("Press Enter to finish.")
        Console.ReadLine()
    End Sub
End Module
' </Snippet1>

