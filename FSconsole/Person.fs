module Person


    type Vector2D(dx : float, dy : float) = 
        /// The length of the vector, computed when the object is constructed
        let length = sqrt (dx*dx + dy*dy)

        // 'this' specifies a name for the object's self identifier.
        // In instance methods, it must appear before the member name.
        member this.DX = dx  

        member this.DY = dy

        member this.Length = length

        member this.Scale(k) = Vector2D(k * this.DX, k * this.DY)
