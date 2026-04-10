using System;
using Godot;

namespace TowerDefence.Towers;

public partial class Tower : Node2D
{
	private static readonly Texture2D BlueTowerTexture = GD.Load<Texture2D>("res://Towers/Blue.png");
	private static readonly Texture2D GreenTowerTexture = GD.Load<Texture2D>("res://Towers/Green.png");
	private static readonly Texture2D RedTowerTexture = GD.Load<Texture2D>("res://Towers/Red.png");
	private static readonly Texture2D YellowTowerTexture = GD.Load<Texture2D>("res://Towers/Yellow.png");
	
	private Sprite2D? _towerSprite;
	private Sprite2D TowerSprite
	{
		get
		{
			_towerSprite ??= GetNode<Sprite2D>("TowerSprite");
			return _towerSprite;
		}
	}
	private TowerTypes _towerType = TowerTypes.Blue;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void SetTowerType(TowerTypes towerType)
	{
		_towerType = towerType;
		SetTowerSpriteTexture();
		GD.Print($"Tower Type: {_towerType}");
	}

	private void SetTowerSpriteTexture()
	{
		TowerSprite.Texture = _towerType switch
		{
			TowerTypes.Blue => BlueTowerTexture,
			TowerTypes.Green => GreenTowerTexture,
			TowerTypes.Red => RedTowerTexture,
			TowerTypes.Yellow => YellowTowerTexture,
			_ => throw new ArgumentOutOfRangeException()
		};
	}
}

public enum TowerTypes
{
	Blue = 0,
	Green = 1,
	Red = 2,
	Yellow = 3,
}