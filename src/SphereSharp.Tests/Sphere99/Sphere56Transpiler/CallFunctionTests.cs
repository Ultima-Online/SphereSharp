﻿using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SphereSharp.Sphere99;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SphereSharp.Tests.Sphere99.Sphere56Transpiler
{
    [TestClass]
    public class CallFunctionTests
    {
        [TestMethod]
        [DataRow("fun1", "fun1")]
        [DataRow("<argv(1)>_<arg(u)>", "<argv[1]>_<local.u>")]
        [DataRow("fun1()", "fun1")]
        [DataRow("fun1(-1)", "fun1 -1")]
        [DataRow("fun1_2", "fun1_2")]
        [DataRow("fun1_2(3)", "fun1_2 3")]
        [DataRow("fun1_2(3,4,5)", "fun1_2 3,4,5")]
        [DataRow("a.b.c.fun1", "a.b.c.fun1")]
        [DataRow("a.b.c.fun1(1,2,3)", "a.b.c.fun1 1,2,3")]
        [DataRow("sysmessage(Zameruj jen monstra)", "sysmessage Zameruj jen monstra")]
        [DataRow("fun1(<eval fun2>)", "fun1 <eval <fun2>>")]
        [DataRow("fun1(<eval fun2(1,2,3)>)", "fun1 <eval <fun2 1,2,3>>")]
        [DataRow("fun1(<eval fun2(<eval 1>,<eval 2>,<eval 3>)>)", "fun1 <eval <fun2 <eval 1>,<eval 2>,<eval 3>>>")]
        public void Can_transpile_custom_function_calls(string src, string expectedResult)
        {
            TranspileStatementCheck(src, expectedResult);
        }

        [TestMethod]
        [DataRow("args.color", "<args>.color")]
        [DataRow("<args>.color", "<args>.color")]
        [DataRow("arg(x,<eval argv>)", "local.x=<eval <args>>")]
        public void Arguments(string src, string expectedResult)
        {
            TranspileStatementCheck(src, expectedResult);
        }

        [TestMethod]
        [DataRow("sysmessage(\"\")", "sysmessage \"\"")]
        [DataRow("sysmessage(\"<fun1>\")", "sysmessage \"<fun1>\"")]
        [DataRow("sysmessage(\"<fun1(1,2,3)>\")", "sysmessage \"<fun1 1,2,3>\"")]
        [DataRow("sysmessage(\"<?fun1(1,2,3)?>\")", "sysmessage \"<fun1 1,2,3>\"")]
        [DataRow("sysmessage(\"<arg(x)>\")", "sysmessage \"<local.x>\"")]
        public void QuotedArguments(string src, string expectedResult)
        {
            TranspileStatementCheck(src, expectedResult);
        }

        [TestMethod]
        [DataRow("sysmessage Some text <fun1>", "sysmessage Some text <fun1>")]
        [DataRow("sysmessage Some text <fun1(1,2,3)>", "sysmessage Some text <fun1 1,2,3>")]
        [DataRow("sysmessage Some text <?fun1(1,2,3)?>", "sysmessage Some text <fun1 1,2,3>")]
        [DataRow("sysmessage Some text <arg(x)>", "sysmessage Some text <local.x>")]
        [DataRow("arg(x,Some text <arg(x)>)", "local.x=Some text <local.x>")]
        [DataRow("arg(x,Some text <?arg(x)?>)", "local.x=Some text <local.x>")]
        public void UnquotedArguments(string src, string expectedResult)
        {
            TranspileStatementCheck(src, expectedResult);
        }

        [TestMethod]
        [DataRow("lastnew.bounce", "new.bounce")]
        [DataRow("equip <lastnew>", "equip <new>")]
        [DataRow("equip lastnew", "equip <new>")]
        [DataRow("lastnew.timer=300", "new.timer=300")]
        [DataRow("arg(u,<Skill_Enticement.effect>)", "local.u=<serv.skill.enticement.effect>")]
        [DataRow("region.flag_underground", "region.underground")]
        [DataRow("profession=class_<arg(class)>", "skillclass=class_<local.class>")]
        [DataRow("return <profession>", "return <skillclass>")]
        public void Name_transformation(string src, string expectedResult)
        {
            TranspileStatementCheck(src, expectedResult);
        }

        [TestMethod]
        [DataRow("morex=0", "morex=0")]
        public void Assignment(string src, string expectedResult)
        {
            TranspileStatementCheck(src, expectedResult);
        }

        [TestMethod]
        [DataRow("<fun1>", "<fun1>")]
        [DataRow("(<fun1>)", "(<fun1>)")]
        [DataRow("fun1", "<fun1>")]
        [DataRow("(fun1)", "(<fun1>)")]
        [DataRow("(fun1==fun2)", "(<fun1>==<fun2>)")]
        [DataRow("{1 2}", "{1 2}")]
        [DataRow("<eval 123>", "<eval 123>")]
        [DataRow("tag(u)", "<tag0.u>")]
        [DataRow("var(u)", "<var0.u>")]
        [DataRow("<findid(i_item)>", "<findid.i_item>")]
        [DataRow("arg(length)", "<local.length>")]
        public void Conditions(string src, string expectedResult)
        {
            TranspileConditionCheck(src, expectedResult);
        }

        [TestMethod]
        public void Safe()
        {
            TranspileStatementCheck("safe(findid.i_something.remove)", "findid.i_something.remove");
            TranspileStatementCheck("safe findid.i_something.remove", "findid.i_something.remove");
            TranspileStatementCheck("safe(cast 020)", "cast 020");
            TranspileStatementCheck("safe(events=+e_something)", "events=+e_something");
            TranspileConditionCheck("safe finduid(<argv(0)>).isChar", "<finduid.<argv[0]>.isChar>");
            TranspileConditionCheck("safe(finduid(<argv(0)>).isChar)", "<finduid.<argv[0]>.isChar>");
            TranspileConditionCheck("safe.tag(orig_stealth)", "<tag0.orig_stealth>");
            TranspileConditionCheck("<safe.tag(orig_stealth)>", "<tag0.orig_stealth>");
            TranspileConditionCheck("safe(<eval (<args>)>)", "<eval (<args>)>");
        }

        [TestMethod]
        public void While_statement()
        {
            TranspileStatementCheck(@"while 1
    call1
endwhile",

@"while 1
    call1
endwhile");

            TranspileStatementCheck(@"while 1
endwhile",

@"while 1
endwhile");

            TranspileStatementCheck(@"while 1
    while 2
    endwhile
endwhile",

@"while 1
    while 2
    endwhile
endwhile");
        }

        [TestMethod]
        public void If_statement()
        {
            TranspileStatementCheck(@"if 1
    call1
endif",
@"if 1
    call1
endif");

            TranspileStatementCheck(@"if 1
    if 2
        call1
    endif
endif",
@"if 1
    if 2
        call1
    endif
endif");

            TranspileStatementCheck(@"if 1
    call1
else
    call2
endif",
@"if 1
    call1
else
    call2
endif");

            TranspileStatementCheck(@"if 1
    call1
elseif 2
    call2
else
    call3
endif",
@"if 1
    call1
elseif 2
    call2
else
    call3
endif");
            TranspileStatementCheck(@"if 1
    call1
elseif 2
    call2
elseif 3
    call3
else
    call4
endif",
@"if 1
    call1
elseif 2
    call2
elseif 3
    call3
else
    call4
endif");

            TranspileStatementCheck(@"if(0)
    call1
endif",
@"if (0)
    call1
endif");
        }

        [TestMethod]
        [DataRow("return 1", "return 1")]
        [DataRow("return<x>", "return <x>")]
        [DataRow("return <x>", "return <x>")]
        [DataRow("trigger timer", "trigger @timer")]
        [DataRow("trigger @timer", "trigger @timer")]
        [DataRow("trigger(@timer)", "trigger @timer")]
        [DataRow("trigger(timer)", "trigger @timer")]
        [DataRow("go 4764,1362,10", "go 4764,1362,10")]
        [DataRow("findid(i_rune_discordance).remove", "findid.i_rune_discordance.remove")]
        [DataRow("findid(i_rune_discordance)", "findid.i_rune_discordance")]
        [DataRow("isevent(e_something)", "isevent.e_something")]
        [DataRow("isevent e_something", "isevent.e_something")]
        [DataRow("isevent.e_something", "isevent.e_something")]
        public void Native_functions(string source, string expectedResult)
        {
            TranspileStatementCheck(source, expectedResult);
        }

        [TestMethod]
        [DataRow("arg(length,<strlen(<argv(1)>)>+45)", "local.length=<eval strlen(<argv[1]>)>+45")]
        [DataRow("arg(length,strlen(<argv(1)>)+45)", "local.length=<eval strlen(<argv[1]>)>+45")]
        [DataRow("arg(length,<eval strlen(<argv(1)>)>+45)", "local.length=<eval strlen(<argv[1]>)>+45")]
        [DataRow("arg(u,<eval strcmpi(<argv(0)>,<argv(1)>)>)", "local.u=<eval strcmpi(<argv[0]>,<argv[1]>)>")]
        public void Special_functions(string source, string expectedResult)
        {
            TranspileStatementCheck(source, expectedResult);
        }

        [TestMethod]
        [DataRow("arg(u,1)", "local.u=1")]
        [DataRow("arg(u,#+1)", "local.u=<local.u>+1")]
        [DataRow("arg(u,arg(v))", "local.u=<local.v>")]
        [DataRow("arg(u,<argcount>)", "local.u=<argv>")]
        [DataRow("arg(u,<argv(0)>)", "local.u=<argv[0]>")]
        [DataRow("arg(u,<arg(u)>,<arg(v)>)", "local.u=<local.u>,<local.v>")]
        [DataRow("arg.u=0", "local.u=0")]
        [DataRow("arg.u=<arg.u>", "local.u=<local.u>")]
        [DataRow("equip(arg(hiditem))", "equip <local.hiditem>")]
        public void Local_variables(string source, string expectedResult)
        {
            TranspileStatementCheck(source, expectedResult);
        }

        [TestMethod]
        public void Induced_uid()
        {
            TranspileStatementCheck("arg(v,<arg(u).name>)", "local.v=<uid.<local.u>.name>");
            TranspileStatementCheck("arg(name,<tag(detect_src).name>)", "local.name=<uid.<tag.detect_src>.name>");
            TranspileStatementCheck("arg(name,<var(detect_src).name>)", "local.name=<uid.<var.detect_src>.name>");

            TranspileConditionCheck("<eval arg(x).flags>", "<eval <uid.<local.x>.flags>>");
        }

        [TestMethod]
        public void Can_recognize_local_variable_read_access()
        {
            TranspileFileCheck(@"[function fun1]
arg(xxx,1)
arg(yyy,<eval <xxx>>)
yyy.color=1
equip(xxx)",
@"[function fun1]
local.xxx=1
local.yyy=<eval <local.xxx>>
local.yyy.color=1
equip <local.xxx>");
        }

        [TestMethod]
        public void Function_is_local_variable_scope()
        {
            TranspileFileCheck(@"[function fun1]
if 1
    arg(variable1,1)
else
    arg(variable1,2)
endif

variable1=<variable1>

[function fun2]
variable1
", @"[function fun1]
if 1
    local.variable1=1
else
    local.variable1=2
endif

local.variable1=<local.variable1>

[function fun2]
variable1
");
        }

        [TestMethod]
        public void Trigger_name_translation()
        {
            TranspileFileCheck(@"[itemdef i_item]
on=@UserDClick
on=@spellcast
",
@"[itemdef i_item]
on=@dclick
on=@spellselect");

        }

        [TestMethod]
        public void Trigger_is_local_variable_scope()
        {
            TranspileFileCheck(@"[itemdef i_item]
ID=i_memory

on=@trigger1
if 1
    arg(variable1,1)
endif
variable1=<variable1>",
@"[itemdef i_item]
ID=i_memory

on=@trigger1
if 1
    local.variable1=1
endif
local.variable1=<local.variable1>");
        }

        [TestMethod]
        public void Can_recognize_global_variable_read_access()
        {
            TranspileCodeBlockCheck(@"var(xxx,1)
var(yyy,<eval <xxx>>)",
@"var.xxx=1
var.yyy=<eval <var.xxx>>");

            TranspileCodeBlockCheck(@"var(asciitext,1)
var(asciitext,1)",
@"var.asciitext=1
var.asciitext=1");
        }

        [TestMethod]
        [DataRow("tag(name,value)", "tag.name=value")]
        [DataRow("arg(u,tag(name))", "local.u=tag.name")]
        [DataRow("tag.remove(u)", "tag.u=")]
        [DataRow("tag.u.remove", "tag.u=")]
        [DataRow("tag(name,value1,value2)", "tag.name=value1,value2")]
        [DataRow("tag(name[<tag(index)>],value)", "tag.name[<tag0.index>]=value")]
        [DataRow("link.timerd=<link.tag.hitspeed>", "link.timerd=<link.tag.hitspeed>")]
        public void Tags(string source, string expectedResult)
        {
            TranspileStatementCheck(source, expectedResult);
        }

        [TestMethod]
        [DataRow("var(name,value)", "var.name=value")]
        [DataRow("arg(u,var(name))", "local.u=var.name")]
        public void Global_variables(string source, string expectedResult)
        {
            TranspileStatementCheck(source, expectedResult);
        }

        [TestMethod]
        [DataRow("findlayer(layer_pack).remove", "findlayer.layer_pack.remove")]
        [DataRow("arg(u,findlayer(layer_pack))", "local.u=findlayer layer_pack")]
        public void DottedArguments(string source, string expectedResult)
        {
            TranspileStatementCheck(source, expectedResult);
        }

        [TestMethod]
        public void Can_transpile_function()
        {
            TranspileFileCheck(
@"[function fun1]
call1
call2",

@"[function fun1]
call1
call2");
        }

        [TestMethod]
        public void TypeDefs_section()
        {
            TranspileFileCheck(@"[TYPEDEFS]
t_normal                  0
t_container               1",

@"[TYPEDEFS]
t_normal                  0
t_container               1
[function t_normal]
return 0

[function t_container]
return 1");
        }

        [TestMethod]
        public void DefNames_section()
        {
            TranspileFileCheck(@"[DEFNAMES blockedIPs]
d_blocked_ips        0",
@"[defname blockedIPs]
d_blocked_ips        0

[function d_blocked_ips]
return 0");
        }

        [TestMethod]
        public void Speech_section()
        {
            TranspileFileCheck(@"[SPEECH spk_human_prime]
ON=*
    call1

ON=*hire*
    call2

ON=*train*
ON=*teach*
    call3",
@"[SPEECH spk_human_prime]
ON=*
    call1

ON=*hire*
    call2

ON=*train*
ON=*teach*
    call3");
        }

        [TestMethod]
        public void Comment_section()
        {
            TranspileFileCheck(@"[COMMENT]
comment line 1
comment line 2
",
@"[COMMENT]
comment line 1
comment line 2

");
        }

        [TestMethod]
        [DataRow("name=fullspawner (.x spawnfull)", "name=fullspawner (.x spawnfull)")]
        [DataRow("WEIGHT=", "WEIGHT=")]
        public void Property(string source, string expectedResult)
        {
            TranspilePropertyAssignmentCheck(source, expectedResult);
        }

        [TestMethod]
        public void Findres()
        {
            TranspileConditionCheck("<findres(chardef,tag.spawnID).defname>", "<serv.chardef.<tag.spawnID>.defname>");
            TranspileConditionCheck("<findres(chardef, tag.spawnID).defname>", "<serv.chardef.<tag.spawnID>.defname>");
            TranspileConditionCheck("<findres(skill,<arg(u)>).name>", "<serv.skill.<local.u>.name>");
            TranspileConditionCheck("<findres(spell,<args>).flags>", "<serv.spell.<args>.flags>");
            TranspileConditionCheck("findres(itemdef,arg(createID))", "<serv.itemdef.<local.createID>>");
            TranspileStatementCheck("arg(x,<findres(skill,arg(i)).name>)", "local.x=<serv.skill.<local.i>.name>");
        }

        private void TranspileStatementCheck(string input, string expectedOutput)
            => TranspileCheck(input, expectedOutput, (src, parser) => parser.ParseStatement(src));

        private void TranspileFileCheck(string input, string expectedOutput)
            => TranspileCheck(input, expectedOutput, (src, parser) => parser.ParseFile(src));

        private void TranspileConditionCheck(string input, string expectedOutput)
            => TranspileCheck(input, expectedOutput, (src, parser) => parser.ParseCondition(src));

        private void TranspileCodeBlockCheck(string input, string expectedOutput)
            => TranspileCheck(input, expectedOutput, (src, parser) => parser.ParseCodeBlock(src));

        private void TranspilePropertyAssignmentCheck(string input, string expectedOutput)
            => TranspileCheck(input, expectedOutput, (src, parser) => parser.ParsePropertyAssignment(src));

        private void TranspileCheck(string input, string expectedOutput, Func<string, SphereSharp.Sphere99.Parser, ParsingResult> parseFunc)
        {
            var parser = new SphereSharp.Sphere99.Parser();
            var parsingOutput = parseFunc(input, parser);

            if (parsingOutput.Errors.Any())
            {
                Assert.Fail(parsingOutput.GetErrorsText());
            }

            var transpiler = new SphereSharp.Sphere99.Sphere56TranspilerVisitor();
            transpiler.Visit(parsingOutput.Tree);

            transpiler.Output.Trim().Should().Be(expectedOutput.Trim());
        }
    }
}
