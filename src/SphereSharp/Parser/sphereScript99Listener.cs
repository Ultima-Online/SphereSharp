//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from /work/sphereScript99.g4 by ANTLR 4.7

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="sphereScript99Parser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7")]
[System.CLSCompliant(false)]
public interface IsphereScript99Listener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="sphereScript99Parser.file"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFile([NotNull] sphereScript99Parser.FileContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="sphereScript99Parser.file"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFile([NotNull] sphereScript99Parser.FileContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="sphereScript99Parser.section"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSection([NotNull] sphereScript99Parser.SectionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="sphereScript99Parser.section"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSection([NotNull] sphereScript99Parser.SectionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="sphereScript99Parser.eofSection"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEofSection([NotNull] sphereScript99Parser.EofSectionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="sphereScript99Parser.eofSection"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEofSection([NotNull] sphereScript99Parser.EofSectionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="sphereScript99Parser.functionSection"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunctionSection([NotNull] sphereScript99Parser.FunctionSectionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="sphereScript99Parser.functionSection"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunctionSection([NotNull] sphereScript99Parser.FunctionSectionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="sphereScript99Parser.functionSectionHeader"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunctionSectionHeader([NotNull] sphereScript99Parser.FunctionSectionHeaderContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="sphereScript99Parser.functionSectionHeader"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunctionSectionHeader([NotNull] sphereScript99Parser.FunctionSectionHeaderContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="sphereScript99Parser.codeBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCodeBlock([NotNull] sphereScript99Parser.CodeBlockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="sphereScript99Parser.codeBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCodeBlock([NotNull] sphereScript99Parser.CodeBlockContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="sphereScript99Parser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStatement([NotNull] sphereScript99Parser.StatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="sphereScript99Parser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStatement([NotNull] sphereScript99Parser.StatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="sphereScript99Parser.macro"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMacro([NotNull] sphereScript99Parser.MacroContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="sphereScript99Parser.macro"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMacro([NotNull] sphereScript99Parser.MacroContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="sphereScript99Parser.call"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCall([NotNull] sphereScript99Parser.CallContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="sphereScript99Parser.call"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCall([NotNull] sphereScript99Parser.CallContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="sphereScript99Parser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAssignment([NotNull] sphereScript99Parser.AssignmentContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="sphereScript99Parser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAssignment([NotNull] sphereScript99Parser.AssignmentContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="sphereScript99Parser.memberAccess"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMemberAccess([NotNull] sphereScript99Parser.MemberAccessContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="sphereScript99Parser.memberAccess"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMemberAccess([NotNull] sphereScript99Parser.MemberAccessContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="sphereScript99Parser.chainedMemberAccess"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterChainedMemberAccess([NotNull] sphereScript99Parser.ChainedMemberAccessContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="sphereScript99Parser.chainedMemberAccess"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitChainedMemberAccess([NotNull] sphereScript99Parser.ChainedMemberAccessContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="sphereScript99Parser.memberName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMemberName([NotNull] sphereScript99Parser.MemberNameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="sphereScript99Parser.memberName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMemberName([NotNull] sphereScript99Parser.MemberNameContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="sphereScript99Parser.enclosedArgumentList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEnclosedArgumentList([NotNull] sphereScript99Parser.EnclosedArgumentListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="sphereScript99Parser.enclosedArgumentList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEnclosedArgumentList([NotNull] sphereScript99Parser.EnclosedArgumentListContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="sphereScript99Parser.argumentList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArgumentList([NotNull] sphereScript99Parser.ArgumentListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="sphereScript99Parser.argumentList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArgumentList([NotNull] sphereScript99Parser.ArgumentListContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="sphereScript99Parser.argument"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArgument([NotNull] sphereScript99Parser.ArgumentContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="sphereScript99Parser.argument"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArgument([NotNull] sphereScript99Parser.ArgumentContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="sphereScript99Parser.expressionArgument"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpressionArgument([NotNull] sphereScript99Parser.ExpressionArgumentContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="sphereScript99Parser.expressionArgument"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpressionArgument([NotNull] sphereScript99Parser.ExpressionArgumentContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="sphereScript99Parser.unquotedLiteralArgument"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterUnquotedLiteralArgument([NotNull] sphereScript99Parser.UnquotedLiteralArgumentContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="sphereScript99Parser.unquotedLiteralArgument"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitUnquotedLiteralArgument([NotNull] sphereScript99Parser.UnquotedLiteralArgumentContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="sphereScript99Parser.signedOperand"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSignedOperand([NotNull] sphereScript99Parser.SignedOperandContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="sphereScript99Parser.signedOperand"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSignedOperand([NotNull] sphereScript99Parser.SignedOperandContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="sphereScript99Parser.operand"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOperand([NotNull] sphereScript99Parser.OperandContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="sphereScript99Parser.operand"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOperand([NotNull] sphereScript99Parser.OperandContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="sphereScript99Parser.binaryOperation"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBinaryOperation([NotNull] sphereScript99Parser.BinaryOperationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="sphereScript99Parser.binaryOperation"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBinaryOperation([NotNull] sphereScript99Parser.BinaryOperationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="sphereScript99Parser.operator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOperator([NotNull] sphereScript99Parser.OperatorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="sphereScript99Parser.operator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOperator([NotNull] sphereScript99Parser.OperatorContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="sphereScript99Parser.constantExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterConstantExpression([NotNull] sphereScript99Parser.ConstantExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="sphereScript99Parser.constantExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitConstantExpression([NotNull] sphereScript99Parser.ConstantExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="sphereScript99Parser.macroExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMacroExpression([NotNull] sphereScript99Parser.MacroExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="sphereScript99Parser.macroExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMacroExpression([NotNull] sphereScript99Parser.MacroExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="sphereScript99Parser.subExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSubExpression([NotNull] sphereScript99Parser.SubExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="sphereScript99Parser.subExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSubExpression([NotNull] sphereScript99Parser.SubExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="sphereScript99Parser.macroOperator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMacroOperator([NotNull] sphereScript99Parser.MacroOperatorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="sphereScript99Parser.macroOperator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMacroOperator([NotNull] sphereScript99Parser.MacroOperatorContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="sphereScript99Parser.constantOperator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterConstantOperator([NotNull] sphereScript99Parser.ConstantOperatorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="sphereScript99Parser.constantOperator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitConstantOperator([NotNull] sphereScript99Parser.ConstantOperatorContext context);
}
