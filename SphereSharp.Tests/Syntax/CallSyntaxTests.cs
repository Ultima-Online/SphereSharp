﻿using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SphereSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SphereSharp.Tests.Syntax
{
    [TestClass]
    public class CustomFunctionCallTests
    {
        [TestMethod]
        public void Can_call_function_with_one_number_argument()
        {
            var syntax = CallSyntax.ParseCustom("fun1(123)");

            syntax.Arguments._Arguments.Should().HaveCount(1);
            var argument1 = syntax.Arguments._Arguments[0].Should().BeOfType<_ExpressionArgumentSyntax>();
        }
    }

    [TestClass]
    public class CallSyntaxTests
    {
        [TestMethod]
        public void Can_call_function_without_arguments()
        {
            var syntax = CallSyntax.Parse("raceclass_nations");

            syntax.MemberName.Should().Be("raceclass_nations");
            syntax.Arguments.IsEmpty.Should().BeTrue();
        }

        [TestMethod]
        public void Can_call_function_with_arguments()
        {
            var syntax = CallSyntax.Parse("dialogclose(D_RACEclass_background,0)");

            syntax.MemberName.Should().Be("dialogclose");
            syntax.Arguments.IsEmpty.Should().BeFalse();
        }

        [TestMethod]
        public void Can_access_nested_members()
        {
            var syntax = CallSyntax.Parse("src.link.tag(tag1).dialog D_RACEclass_background");

            syntax.MemberName.Should().Be("src");
            syntax.Arguments.Arguments.Should().HaveCount(0);
            syntax.ChainedCall.MemberName.Should().Be("link");
            syntax.ChainedCall.Arguments.Arguments.Should().HaveCount(0);
            syntax.ChainedCall.ChainedCall.MemberName.Should().Be("tag");
            syntax.ChainedCall.ChainedCall.Arguments.Arguments.Should().HaveCount(1);
        }

        [TestMethod]
        public void Can_parse_function_call_with_macros()
        {
            var syntax = CallSyntax.Parse("func_<tag(test)>");

            syntax.MemberNameSyntax.Segments[0].As<TextSegmentSyntax>().Text.Should().Be("func_");
            syntax.MemberNameSyntax.Segments[1].As<MacroSegmentSyntax>().Macro.Expression
                .Should().BeOfType<CallExpressionSyntax>().Which.Call.MemberNameSyntax.Segments[0].As<TextSegmentSyntax>().Text.Should().Be("tag");
        }

        [TestMethod]
        public void Can_parse_function_call_with_macro_argument_with_array_access()
        {
            var syntax = CallSyntax.Parse("strlen(<def_class[argn]>)");

            var argumentLiteral = syntax.Arguments.Arguments[0].Should().BeOfType<LiteralArgumentSyntax>().Which.Literal;

            argumentLiteral.Segments.Should().HaveCount(1);
            var macro = argumentLiteral.Segments[0].Should().BeOfType<MacroSegmentSyntax>().Which.Macro;
            var indexedSymbol = macro.Expression
                .Should().BeOfType<CallExpressionSyntax>().Which.Call.MemberNameSyntax.Should().BeOfType<IndexedSymbolSyntax>().Which;
            var indexCall = indexedSymbol.Index.Should().BeOfType<CallExpressionSyntax>().Which.Call;
            indexCall.MemberName.Should().Be("argn");
        }

        [TestMethod]
        public void Cannot_parse_trigger_header()
        {
            Action testedAction = () => CallSyntax.Parse("on=@userdclick");
            testedAction.Should().Throw<Exception>();
        }

        [TestMethod]
        public void Can_parse_call_with_safe_literal()
        {
            var syntax = CallSyntax.Parse("func(<?safe?>something safe)");

            syntax.Arguments.Arguments.Should().HaveCount(1);
            var argumentLiteral = syntax.Arguments.Arguments[0].Should().BeOfType<LiteralArgumentSyntax>().Which.Literal;
            argumentLiteral.Segments.Should().HaveCount(1);
            argumentLiteral.Segments[0].Should().BeOfType<TextSegmentSyntax>().Which.Text.Should().Be("something safe");
        }

        [TestMethod]
        public void Can_parse_call_with_literal_inside_parentheses_without_doublequotes()
        {
            var syntax = CallSyntax.Parse("sysmessage(Pohybem jsi ztratil soustredeni)");

            syntax.Arguments.Arguments.Should().HaveCount(1);
            var argumentSyntax = syntax.Arguments.Arguments[0].Should().BeOfType<LiteralArgumentSyntax>().Which;
            argumentSyntax.Literal.Text.Should().Be("Pohybem jsi ztratil soustredeni");
        }

        [TestMethod]
        public void Can_parse_call_with_literal_with_macro_inside_parentheses_without_doublequotes()
        {
            var syntax = CallSyntax.Parse("sysmessage(Pohybem jsi <topobje.p> ztratil soustredeni)");

            syntax.Arguments.Arguments.Should().HaveCount(1);
            var argumentSyntax = syntax.Arguments.Arguments[0].Should().BeOfType<LiteralArgumentSyntax>().Which;
            argumentSyntax.Literal.Segments.Should().HaveCount(3);
        }

        [TestMethod]
        public void Can_parse_call_expression_as_argument_for_argv()
        {
            var syntax = CallSyntax.Parse("argv(arg(u))");

            syntax.Arguments.Arguments.Should().HaveCount(1);
            var argument = syntax.Arguments.Arguments[0].Should().BeOfType<ExpressionArgumentSyntax>();
        }

        [TestMethod]
        public void Can_call_restest_with_resource_argument_without_doublequotes()
        {
            var syntax = CallSyntax.Parse("restest 1 i_scroll_blank");

            syntax.Arguments.Arguments.Should().HaveCount(1);
            syntax.Arguments.Arguments[0].Should().BeOfType<ResourceArgumentSyntax>();
        }

        [TestMethod]
        public void Can_parse_call_to_specific_builtin_functions_without_argument_parentheses()
        {
            CallSyntax.Parse("dialog d_raceclass_nations").Should().BeOfType<CallSyntax>().Which.Arguments.Arguments.Should().HaveCount(1);
            CallSyntax.Parse("resizepic 0 0 2600 640 480").Should().BeOfType<CallSyntax>().Which.Arguments.Arguments.Should().HaveCount(5);
            CallSyntax.Parse("gumppic 510 110 5536").Should().BeOfType<CallSyntax>().Which.Arguments.Arguments.Should().HaveCount(3);
        }

        [TestMethod]
        public void Can_parse_call_to_specific_builtin_functions_with_argument_parentheses()
        {
            CallSyntax.Parse("dialog(d_raceclass_nations)").Should().BeOfType<CallSyntax>().Which.Arguments.Arguments.Should().HaveCount(1);
            CallSyntax.Parse("resizepic(0, 0, 2600, 640, 480)").Should().BeOfType<CallSyntax>().Which.Arguments.Arguments.Should().HaveCount(5);
            CallSyntax.Parse("gumppic(510, 110, 5536)").Should().BeOfType<CallSyntax>().Which.Arguments.Arguments.Should().HaveCount(3);
        }
    }
}
