﻿using System;
namespace OOPShogi.Piece
{
    public class Knight: BPiece
    {
        public Knight(bool isWhite): base(EPieceSort.kKnight, isWhite){}

		public override bool CanPromote()
		{
            return base.CanPromote();
		}

		public override bool CanJump()
		{
            return !IsPromoted;
		}

		public override bool HasControlTo(Coord coord)
		{
            if (!IsPromoted)
                return coord == (Forward * 2 + Right) ||
                       coord == (Forward * 2 + Left);
            else
                return IsInsideGoldControl(coord);
		}
	}
}
