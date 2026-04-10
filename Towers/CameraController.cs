using Godot;

namespace TowerDefence.Towers;

public partial class CameraController : Camera2D
{
	private int _scrollSpeed = 500;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("Up"))
		{
			Position += new Vector2(0, -_scrollSpeed) * (float)delta;
		}
		if (Input.IsActionPressed("Down"))
		{
			Position += new Vector2(0, _scrollSpeed) * (float)delta;
		}
		if (Input.IsActionPressed("Left"))
		{
			Position += new Vector2(-_scrollSpeed, 0) * (float)delta;
		}
		if (Input.IsActionPressed("Right"))
		{
			Position += new Vector2(_scrollSpeed, 0) * (float)delta;
		}
	}
}