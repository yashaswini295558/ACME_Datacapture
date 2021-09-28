CREATE PROC usp_Insert_Data(@temp int, @precise_temp nvarchar(60), @coolingagent nvarchar(60), @dates varchar(20), @drivecaptainfname varchar(20), @city varchar(20), @country varchar(20), @countryCode varchar(20))
AS
BEGIN
BEGIN TRY
IF @temp IS NOT NULL
	BEGIN
		IF @precise_temp IS NOT NULL
			BEGIN
				IF @coolingagent IS NOT NULL
					BEGIN
						IF @dates IS NOT NULL
							BEGIN
								IF @drivecaptainfname IS NOT NULL
									BEGIN
										IF @city IS NOT NULL
											BEGIN
												IF @country IS NOT NULL
													BEGIN
														IF @countryCode IS NOT NULL
															BEGIN
																INSERT INTO dbo.Datarecieved(temp, precise_temp, coolingagent,dates, drivecaptainfname, city, country, countryCode) VALUES (@temp, @precise_temp, @coolingagent, @dates, @drivecaptainfname, @city, @country, @countryCode )
															END
															ELSE
																RETURN -8
													END
													ELSE
														RETURN -7
											END
											ELSE
												RETURN -6
									END
									ELSE
										RETURN -5
							END
							ELSE
								RETURN -4
					END
					ELSE
						RETURN -3
			END
			ELSE
				RETURN -2
	END
	ELSE
		RETURN -1
END TRY 

BEGIN CATCH
	RETURN -99
END CATCH
END

DECLARE @ret INT
EXEC @ret=usp_Insert_Data '2', '71.108', 'true', '1980-06-11', 'Felizio', 'Bucharest', 'Tajikistan', 'JP'
SELECT @ret

SELECT * FROM dbo.Datarecieved