﻿using System;
using HandMenu.Input;
using UnityEngine;

namespace HandMenu.State {

	/*================================================================================================*/
	public class MenuPointState {

		public PointData.PointZone Zone { get; set; }
		public bool IsActive { get; private set; }
		public Vector3 Position { get; private set; }
		public Quaternion Rotation { get; private set; }
		public float Extension { get; private set; }
		public float SelectionProgress { get; private set; }

		private readonly PointProvider vPointProv;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MenuPointState(PointData.PointZone pZone, PointProvider pPointProv) {
			Zone = pZone;
			vPointProv = pPointProv;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void UpdateAfterInput() {
			PointData data = vPointProv.Data;

			IsActive = (data != null);
			Position = (data == null ? Vector3.zero : data.Position);
			Rotation = (data == null ? Quaternion.identity : data.Rotation);
			Extension = (data == null ? 0 : data.Extension);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void UpdateWithCursor(Vector3? pCursorPosition) {
			if ( pCursorPosition == null ) {
				SelectionProgress = 0;
				return;
			}

			float dist = (Position-(Vector3)pCursorPosition).magnitude;
			float prog = (0.2f-(dist-0.02f))/0.2f;

			SelectionProgress = Math.Max(0, Math.Min(1, prog));
		}

	}

}
