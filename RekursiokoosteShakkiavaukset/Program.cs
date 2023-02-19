using System.CodeDom.Compiler;

var rootMove = Move.GetMoveHierarchy();

using (var output = new StringWriter())
using (var writer = new IndentedTextWriter(output))
{
    rootMove.Operation(writer);
    Console.WriteLine(output);
}

class Move
{
    private readonly List<Move> _children;
    private readonly string _moveNotation;
    private readonly string _openingName;
    private readonly string _eco;

    public Move(string moveNotation, string eco, string openingName, Move? parent)
    {
        _children = new List<Move>();
        _moveNotation = moveNotation;
        _eco = eco;
        _openingName = openingName;
        parent?.AddChild(this);
    }

    public void AddChild(Move move)
    {
        _children.Add(move);
    }

    // not optimal for performance on large scale, but it's a demo
    private string GetMoveString(string moveNotation, int indentLevel)
    {
        var dots = indentLevel % 2 == 0 ? ". " : "...";
        return $"{indentLevel / 2 + 1}{dots}{moveNotation}".PadRight(8);
}

    public void Operation(IndentedTextWriter writer)
    {
        writer.WriteLine($"{GetMoveString(_moveNotation, writer.Indent)} ({_eco}) {_openingName}");
        writer.Indent++;
        foreach (var child in _children)
        {
            child.Operation(writer);
        }
        writer.Indent--;
    }

    /// <summary>
    /// generates a sample move hierarchy
    /// </summary>
    /// <returns>root Move of the hierarchy</returns>
    public static Move GetMoveHierarchy()
    {
        var m1e4 = new Move("e4", "B00", "King's Pawn Game", null);
        var ck_m2c6 = new Move("c6", "B10", "Caro-Kann Defense", m1e4);
        var ck_m3d4 = new Move("d4", "B12", "Caro-Kann Defense", ck_m2c6);
        var ck_m4d5 = new Move("d5", "B12", "Caro-Kann Defense", ck_m3d4);
        var ck_m5e5 = new Move("e5", "B12", "Caro-Kann Defense: Advance Variation", ck_m4d5);
        var ck_m5exd5 = new Move("exd5", "B13", "Caro-Kann Defense: Exchange Variation", ck_m4d5);
        var ck_m5f3 = new Move("f3", "B12", "Caro-Kann Defense: Fantasy Variation", ck_m4d5);
        var ck_m5Nc3 = new Move("Nc3", "B15", "Caro-Kann Defense", ck_m4d5);
        var ck_m3c4 = new Move("c4", "B10", "Caro-Kann Defense: Accelerated Panov Attack", ck_m2c6);
        var ck_m3Bc4 = new Move("Bc4", "B10", "Caro-Kann Defense: Hillbilly Attack", ck_m2c6);
        var fr_m2e6 = new Move("e6", "C00", "French Defense", m1e4);
        var fr_m3d4 = new Move("d4", "C00", "French Defense: Normal Variation", fr_m2e6);
        var fr_m4e5 = new Move("d5", "C00", "French Defense", fr_m3d4);
        var fr_m5e5 = new Move("e5", "C02", "French Defense: Advance Variation", fr_m4e5);
        var fr_m6c5 = new Move("c5", "C02", "French Defense: Advance Variation", fr_m5e5);
        var fr_m7Nf3 = new Move("Nf3", "C02", "French Defense: Advance Variation, Nimzowitsch System", fr_m6c5);
        var fr_m7Qg4 = new Move("Qg4", "C02", "French Defense: Advance Variation, Nimzowitsch Attack", fr_m6c5);
        var fr_m5Nc3 = new Move("Nc3", "C10", "French Defense: Paulsen Variation", fr_m4e5);
        var fr_m6Bb4 = new Move("Bb4", "C15", "French Defense: Winawer Variation", fr_m5Nc3);
        var kp_m2e5 = new Move("e5", "C20", "King's Pawn Game", m1e4);
        var vg_m3Nc3 = new Move("Nc3", "C25", "Vienna Game", kp_m2e5);
        var vg_m4Nf6 = new Move("Nf6", "C26", "Vienna Game: Falkbeer Variation", vg_m3Nc3);
        var vg_m5f4 = new Move("f4", "C29", "Vienna Game: Vienna Gambit", vg_m4Nf6);
        var vg_m5g3 = new Move("g3", "C26", "Vienna Game: Mieses Variation", vg_m4Nf6);
        var vg_m4Nc6 = new Move("Nc6", "C25", "Vienna Game: Max Lange Defense", vg_m3Nc3);
        var vg_m4Bc5 = new Move("Bc5", "C25", "Vienna Game: Anderssen Defense", vg_m3Nc3);
        var kp_m3Nf3 = new Move("Nf3", "C40", "King's Knight Opening", kp_m2e5);
        var kp_m4Nc6 = new Move("Nc6", "C44", "King's Knight Opening: Normal Variation", kp_m3Nf3);
        var kp_m5Bc4 = new Move("Bc4", "C50", "Italian Game", kp_m4Nc6);
        var ig_m6Bc5 = new Move("Bc5", "C50", "Italian Game: Giuoco Piano", kp_m5Bc4);
        var ig_m6Nf6 = new Move("Nf6", "C55", "Italian Game: Two Knights Defense", kp_m5Bc4);
        var kp_m5Bb5 = new Move("Bc4", "C60", "Ruy Lopez", kp_m4Nc6);
        var kp_m5d4 = new Move("d4", "C44", "Scotch Game", kp_m4Nc6);
        var kp_m4Nf6 = new Move("Nf6", "C42", "Petrov's Defense", kp_m3Nf3);
        var bc_m3ke2 = new Move("Ke2", "C20", "Bongcloud Attack", kp_m2e5);

        return m1e4;
    }
}

