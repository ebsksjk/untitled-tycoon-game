using UntitledTycoonGame.Gui.Components;
using UntitledTycoonGame.Gui;
using System.Drawing;

namespace UntitledTycoonGame.Logic;

public class ValueBar : Component {
	//a value bar (box) could look like this:
	//o============o
	//| Test Value |
	//|            |
	//| #####..... |
	//o============o
	//


	int value {get; set;} = 50;		//how full is the bar? (inverted, 100 is empty, 0 ist full)

	bool border {get; set;} = false;	//should the containing box have a border?

	string border_vert {get; set;} = "|"; //border char for vertical lines
	string border_hori {get; set;} = "=";	//border char for horizontal lines
	string border_corn {get; set;} = "o";	//border char for corners

	string empty {get; set;} = ".";		//what char should be used for the empty bar?
	string full {get; set;} = "#"; 		//what char should be used for a filled bar?

	string name {get; set;} = ""; 		//which title should the bar have?

	public ValueBar(int x, int y, int w, int h, string title = ""){
		this.Position = new Point(x, y);
		this.Size = new Size(w, h);

		this.name = title;
	}

	public void setBorder(string vert="|", string hori="=", string corn="o"){
		border_vert = vert;
		border_corn = corn;
		border_hori = corn;
	}

	public void setBar(string fill="#", string empty="."){
		this.full = fill;
		this.empty = empty;
	}

	public override void Render(ConsoleBuffer buffer) {
		//vertical lines
		for(int y = 0; y < this.Size.Height; y++){
			buffer.DrawText(border_vert, new(this.Position.X, this.Position.Y + y));
			buffer.DrawText(border_vert, new(this.Position.X + this.Size.Width, this.Position.Y + y));
		}
		//horizontal lines
		for(int x = 0; x < this.Size.Width; x++){
			buffer.DrawText(border_hori, new(this.Position.X + x, this.Position.Y));
			buffer.DrawText(border_hori, new(this.Position.X + x, this.Position.Y + this.Size.Height));
		}

		//corners
		buffer.DrawText(border_corn, new(this.Position.X, this.Position.Y));
		buffer.DrawText(border_corn, new(this.Position.X + this.Size.Width, this.Position.Y));
		buffer.DrawText(border_corn, new(this.Position.X, this.Position.Y + this.Size.Height));
		buffer.DrawText(border_corn, new(this.Position.X + this.Size.Width, this.Position.Y + this.Size.Height));

		//text
		buffer.DrawText(this.name, new(this.Position.X + 2, this.Position.Y + 1));

		//bar state
		int barLen = this.Size.Width - 4;
		int fillLen = (int)((double)barLen * (double)(this.value/100.0)) + 1;

		//buffer.DrawText($"v:{value},b:{barLen},f:{fillLen}", new(this.Position.X + 2, this.Position.Y + 2));

		int i = 2;
		for(; i < fillLen+2; i++) buffer.DrawText(full.ToString(), new(this.Position.X + i, this.Position.Y + 3));
		for(; i < barLen+2; i++) buffer.DrawText(empty.ToString(), new(this.Position.X + i, this.Position.Y + 3));
	}

	public override void HandleKey(ConsoleKeyInfo key) {}
}

