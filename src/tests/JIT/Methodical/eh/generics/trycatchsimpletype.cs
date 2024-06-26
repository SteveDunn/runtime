// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.IO;
using Xunit;

namespace JIT.Methodical.eh.generics.trycatchsimpletype;

public class GenException<T> : Exception
{
}

public interface IGen
{
    bool ExceptionTest();
}

public class Gen<T> : IGen
{
    public bool ExceptionTest()
    {
        try
        {
            Console.WriteLine("in try");
            throw new GenException<T>();
        }
        catch (GenException<T> exp)
        {
            Console.WriteLine("in catch: " + exp.Message);
            return true;
        }
    }
}

public class Test_trycatchsimpletype
{
    private static TestUtil.TestLog testLog;

    static Test_trycatchsimpletype()
    {
        // Create test writer object to hold expected output
        StringWriter expectedOut = new StringWriter();

        // Write expected output to string writer object
        Exception[] expList = new Exception[] {
            new GenException<int>(),
            new GenException<double>(),
            new GenException<string>(),
            new GenException<object>(),
            new GenException<Exception>()
        };
        for (int i = 0; i < expList.Length; i++)
        {
            expectedOut.WriteLine("in try");
            expectedOut.WriteLine("in catch: " + expList[i].Message);
            expectedOut.WriteLine("{0}", true);
        }

        // Create and initialize test log object
        testLog = new TestUtil.TestLog(expectedOut);

    }

    [Fact]
    public static int TestEntryPoint()
    {
        //Start recording
        testLog.StartRecording();

        // create test list
        IGen[] genList = new IGen[] {
            new Gen<int>(),
            new Gen<double>(),
            new Gen<string>(),
            new Gen<object>(),
            new Gen<Exception>()
        };

        // run test
        for (int i = 0; i < genList.Length; i++)
        {
            Console.WriteLine(genList[i].ExceptionTest());
        }

        // stop recoding
        testLog.StopRecording();

        return testLog.VerifyOutput();
    }

}
