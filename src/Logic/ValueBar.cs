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


	int value {get; set;} = 100;		//how full is the bar? (inverted, 100 is empty, 0 ist full)

	bool border {get; set;} = false;	//should the containing box have a border?

	char border_vert {get; set;} = '|'; //border char for vertical lines
	char border_hori {get; set;} = '=';	//border char for horizontal lines
	char border_corn {get; set;} = 'o';	//border char for corners

	char empty {get; set;} = '.';		//what char should be used for the empty bar?
	char full {get; set;} = '#'; 		//what char should be used for a filled bar?

	string name {get; set;} = ""; 		//which title should the bar have?

	public ValueBar(int x, int y, int w, int h, string title = ""){
		this.Position = new Point(x, y);
		this.Size = new Size(w, h);

		this.name = title;
	}

	public void setBorder(char vert='|', char hori='=', char corn='o'){
		border_vert = vert;
		border_corn = corn;
		border_hori = corn;
	}

	public void setBar(char fill='#', char empty='.'){
		this.full = fill;
		this.empty = empty;
	}

	public override void Render(ConsoleBuffer buffer) {
		//vertical lines
		for(int y = 0; y < this.Size.Height; y++){
			buffer.DrawText(border_vert.ToString(), new(this.Position.X, this.Position.Y + y));
			buffer.DrawText(border_vert.ToString(), new(this.Position.X + this.Size.Width, this.Position.Y + y));
		}
		//horizontal lines
		for(int x = 0; x < this.Size.Width; x++){
			buffer.DrawText(border_hori.ToString(), new(this.Position.X + x, this.Position.Y));
			buffer.DrawText(border_hori.ToString(), new(this.Position.X + x, this.Position.Y + this.Size.Height));
		}

		//corners
		buffer.DrawText(border_corn.ToString(), new(this.Position.X, this.Position.Y));
		buffer.DrawText(border_corn.ToString(), new(this.Position.X + this.Size.Width, this.Position.Y));
		buffer.DrawText(border_corn.ToString(), new(this.Position.X, this.Position.Y + this.Size.Height));
		buffer.DrawText(border_corn.ToString(), new(this.Position.X + this.Size.Width, this.Position.Y + this.Size.Height));

		//text
		buffer.DrawText(this.name, new(this.Position.X + 2, this.Position.Y + 1));
	}

	public override void HandleKey(ConsoleKeyInfo key) {}
}

