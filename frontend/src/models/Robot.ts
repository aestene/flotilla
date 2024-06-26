import { Area } from './Area'
import { BatteryStatus } from './Battery'
import { Installation, placeholderInstallation } from './Installation'
import { Pose } from './Pose'
import { RobotModel, placeholderRobotModel } from './RobotModel'
import { VideoStream } from './VideoStream'

export enum RobotStatus {
    Available = 'Available',
    Busy = 'Busy',
    Offline = 'Offline',
    Blocked = 'Blocked',
    SafeZone = 'Safe Zone',
    ConnectionIssues = 'Connection Issues',
}

export interface Robot {
    id: string
    name?: string
    model: RobotModel
    serialNumber?: string
    currentInstallation: Installation
    batteryLevel?: number
    batteryStatus?: BatteryStatus
    pressureLevel?: number
    pose?: Pose
    status: RobotStatus
    isarConnected: boolean
    deprecated: boolean
    host?: string
    logs?: string
    port?: number
    videoStreams?: VideoStream[]
    isarUri?: string
    currentArea?: Area
    missionQueueFrozen?: boolean
}
export const placeholderRobot: Robot = {
    id: 'placeholderRobotId',
    model: placeholderRobotModel,
    currentInstallation: placeholderInstallation,
    status: RobotStatus.Available,
    isarConnected: true,
    deprecated: false,
}
