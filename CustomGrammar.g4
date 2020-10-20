grammar CustomGrammar;


/*
 * Parser Rules
 */

compileUnit : expression EOF;

expression :
	LPAREN expression RPAREN #ParenthesizedExpr
	| PLUS expression #UnaryPlus
	| MINUS expression #UnaryMinus
	| operatorToken=(INC|DEC) expression #UnaryExpr
	| expression EXPONENT expression #ExponentialExpr
    | expression operatorToken=(MOD | DIVIDE) expression #MultiplicativeExpr
	| expression operatorToken=(PLUS | MINUS) expression #AdditiveExpr	
	| NUMBER #NumberExpr
	; 
   


/*
 * Lexer Rules
 */

NUMBER : INT (',' INT)?; 
INT : ('0'..'9')+;
INC: '++';
DEC: '--';
MINUS : '-';
PLUS : '+';
EXPONENT : '^';
MOD : '%';
DIVIDE : '/';
LPAREN : '(';
RPAREN : ')';

WS : [ \t\r\n] -> channel(HIDDEN);
