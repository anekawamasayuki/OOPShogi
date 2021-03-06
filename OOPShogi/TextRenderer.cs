﻿using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;

using static System.Linq.Enumerable;
using static System.Environment;

using OOPShogi.Piece;

namespace OOPShogi
{
    public class TextRenderer: IRenderer
    {
        private readonly TextWriter _textWriter;

        public TextRenderer(TextWriter textWriter){
            _textWriter = textWriter;
        }

        public void RenderPosition(IPosition position){
            RenderPool(position.GetPool(false));
            RenderBoard(position.GetBoard());
            RenderPool(position.GetPool(true));
            RenderTurn(position.GetTurn());
        }

        public void Write(string s)
        {
            _textWriter.Write(s);
        }

        public void WriteLine(string s)
        {
            _textWriter.WriteLine(s);
        }

        private void RenderBoard(Board board){
            if(board == null){
                Trace.TraceError("board is null");
                Exit(1);
            }
            int row = board.kSize.Row;
            int col = board.kSize.Col;
            foreach (var i in Range(0, row))
            {
                RenderHorizontalLine(col * 2 + (col + 1));
                foreach (var j in Range(0, col))
                {
                    Write("|");
                    RenderPiece(board.GetPiece(new Coord(i, j)));
                }
                WriteLine("|");
            }
            RenderHorizontalLine(col * 2 + (col + 1));
        }

        private void RenderPool(Pool pool)
        {
            // TODO: RenderPoolの実装
            _textWriter.WriteLine($"RenderPool({pool}) called.");
        }

        private void RenderTurn(Turn turn){
            // TODO: RenderTurnの実装
            _textWriter.WriteLine($"RenderTurn({turn}) called.");
        }

        private void RenderPiece(BPiece piece){
            if (piece == null)
            {
                Write("..");
                return;
            }

            if (piece.Promoted) Write("!");
            else                  Write(".");

            switch(piece.Sort){
                case EPieceSort.kKing:
                    Write((piece.White ? "K" : "k"));
                    break;
                case EPieceSort.kRook:
                    Write((piece.White ? "R" : "r"));
                    break;
                case EPieceSort.kBishop:
                    Write((piece.White ? "B" : "b"));
                    break;
                case EPieceSort.kGold:
                    Write((piece.White ? "G" : "g"));
                    break;
                case EPieceSort.kSilver:
                    Write((piece.White ? "S" : "s"));
                    break;
                case EPieceSort.kKnight:
                    Write((piece.White ? "N" : "n"));
                    break;
                case EPieceSort.kLance:
                    Write((piece.White ? "L" : "l"));
                    break;
                case EPieceSort.kPorn:
                    Write((piece.White ? "P" : "p"));
                    break;
            }
        }

        private void RenderHorizontalLine(int count){
            string str = "-";
            for (int i = 1; i < count; i++)
            {
                str += "-";
            }
            WriteLine(str);
        }
    }
}
