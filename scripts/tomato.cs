using Godot;
using System;

public partial class Tomato : Node2D
{
	TomatoGameManager tomatoGameManager;
	private Random rnd = new Random();
	TomatoHitBox hitBox;
	private const float radianRotation = .075f;
	private const float scaleSpeed = .004f;
	private Vector2 minScale = new Vector2(.3f, .3f);
	private float throwSpeed = .01f;
	private float _t = 0.0f;
	private bool isExploded = false;
	private double deSpawnTime = .5f;

	public override void _Ready()
	{
		SetThrowSpeed();
		tomatoGameManager = (TomatoGameManager) GetParent().GetParent();
	}

	public override void _Process(double delta)
	{
		if(isExploded) {
			if(deSpawnTime > 0)
				deSpawnTime -= delta;
			if(deSpawnTime < 0)
				QueueFree();
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		if(isExploded)
			return;
		MyRotation();
		MyScale();
		MyMovement(delta);
	}

	public void MyRotation() {
		Rotate(radianRotation);
	}

	public void MyScale() {
		float scaleX = Scale.X;
		float scaleY = Scale.Y;
		if((scaleX - scaleSpeed) < minScale.X)
			this.Scale = minScale;
		if(scaleX > minScale.X)
			this.Scale = new Vector2(scaleX - scaleSpeed, scaleY - scaleSpeed);
	}

	private void MyMovement(double delta) {
		_t += (float) delta * throwSpeed;
		Position = Position.Lerp(hitBox.Position, _t);
		if(Math.Abs(Position.X - hitBox.Position.X) < 9 && (Math.Abs(Position.Y - hitBox.Position.Y) < 9))
		{
			// if player is in hit box, play success sound
			if(hitBox.isPlayerInHitBox == true)
			{
				//! play sound
				tomatoGameManager.increaseScore();
				QueueFree();
			}
			else 
			{
				tomatoGameManager.resetScore();
				Explode();
			}
		}
	}

	private void Explode() 
	{
		//! play squish sound
		((CanvasItem)GetChild(0)).Hide();
		((CanvasItem)GetChild(1)).Show();
		isExploded = true;
	}

	public void SetHitBox(TomatoHitBox hitBox)
	{
		this.hitBox = hitBox;
	}

	public void SetThrowSpeed()
	{
		float speed = (float) (rnd.NextDouble() * .01);
		throwSpeed += speed;
	}

}
