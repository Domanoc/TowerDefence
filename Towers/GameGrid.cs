using Godot;

namespace TowerDefence.Towers;

public partial class GameGrid : Node2D
{
	private PackedScene _tower = null!; 
	private TowerTypes _towerType = TowerTypes.Blue;
	
	public override void _Ready()
	{
		_tower = GD.Load<PackedScene>("res://Towers/Tower.tscn");
	}
	
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("TowerBlue"))
		{
			_towerType = TowerTypes.Blue;
		}
		if (Input.IsActionJustPressed("TowerGreen"))
		{
			_towerType = TowerTypes.Green;
		}
		if (Input.IsActionJustPressed("TowerRed"))
		{
			_towerType = TowerTypes.Red;
		}
		if (Input.IsActionJustPressed("TowerYellow"))
		{
			_towerType = TowerTypes.Yellow;
		}
	}
	
	public override void _Input(InputEvent inputEvent)
	{
		if (inputEvent is not InputEventMouseButton { Pressed: true } mouseEvent) return;
		var mousePosition = GetGlobalMousePosition();
		var coordinates = mousePosition.ToCoordinates();
		
		var tower = _tower.Instantiate<Tower>();
		tower.Position = coordinates.ToPosition();
		tower.SetTowerType(_towerType);
		AddChild(tower);
	}
}

public static class Vector2Extensions
{
	public static Vector2I ToCoordinates(this Vector2 vector)
	{
		return new Vector2I(
			Mathf.FloorToInt(vector.X / 64), 
			Mathf.FloorToInt(vector.Y / 64));
	}
	public static Vector2 ToPosition(this Vector2I vector)
	{
		return vector * 64 + new Vector2(32, 32);
	}
}